using Models;
using System.Security.Cryptography;

namespace DataAccessLayer
{
    public class FakeCurveData
    {
        private List<CurveData> CurveDataList = new List<CurveData>()
        {
            new CurveData()
            {
                _id = "idString1",
                CurveName = "CurveName1",
                Currency = "CAD",
                CurvePoints = new List<CurvePoint>
                {
                    new CurvePoint()
                    {
                        Date = 20230914,
                        Tenor = "Tenor",
                        Value = 0.05
                    },
                    new CurvePoint()
                    {
                        Date = 20230915,
                        Tenor = "Tenor",
                        Value = 0.04
                    }
                }
            },
            new CurveData()
            {
                _id = "idString2",
                CurveName = "CurveName2",
                Currency = "CAD",
                CurvePoints = new List<CurvePoint>
                {
                    new CurvePoint()
                    {
                        Date = 20230914,
                        Tenor = "Tenor",
                        Value = 0.05
                    },
                    new CurvePoint()
                    {
                        Date = 20230915,
                        Tenor = "Tenor",
                        Value = 0.04
                    }
                }
            }
        };

        // CRUD

        // Read CurveData object by CurveName
        public CurveData GetCurveData(string curveName)
        {
            var result = CurveDataList.Find(n => n.CurveName == curveName);
            return result;
        }

        // Read CurvePoint by CurveName and Date
        public CurvePoint GetCurvePoint(string curveName, int date)
        {
            CurveData curveData = CurveDataList.Find(n => n.CurveName == curveName);
            CurvePoint curvePoint = curveData.CurvePoints.Find(d => d.Date == date);
            return curvePoint;
        }

        // Create CurvePoint in the CurveData by CurveName
        public CurveData CreateCurvePoint(string curveName, CurvePoint curvePoint)
        {
            CurveData curveData = CurveDataList.Find(n => n.CurveName == curveName);
            curveData.CurvePoints.Add(curvePoint);
            return curveData;
        }

        // Update CurvePoint in the CurveData by CurveName
        public CurveData UpdateCurvePoint(string curveName, int date, CurvePoint point)
        {
            CurveData curveData = CurveDataList.Find(n => n.CurveName == curveName);
            CurvePoint curvePoint = curveData.CurvePoints.Find(d => d.Date == date);
            curvePoint.Date = point.Date;
            curvePoint.Tenor = point.Tenor;
            curvePoint.Value = point.Value;
            return curveData;
        }

        // Delete CurvePoint in the CurveData by Date
        public CurveData DeleteCurvePoint(string curveName, int date)
        {
            CurveData curveData = CurveDataList.Find(n => n.CurveName == curveName);
            CurvePoint curvePoint = curveData.CurvePoints.Find(d => d.Date == date);
            curveData.CurvePoints.Remove(curvePoint);
            return curveData;
        }








    }
}