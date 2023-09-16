using Models;
using Interfaces;
using System.Security.Cryptography;

namespace DataAccessLayer
{
    public class FakeCurveData : IDataService
    {
        private List<CurveData> CurveDataList = new List<CurveData>()
        {
            new CurveData()
            {
                _id = "idString1",
                CurveName = "CurveName1",
                Currency = "CAD",
                CurveDate = 20230914,
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
                CurveDate = 20230915,
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

        // Read all.
        public List<CurveData> GetAllCurves()
        {
            return CurveDataList;
        }

        // Read CurveData by CurveName and CurveDate
        public CurveData GetCurveData(string curveName, int curveDate)
        {
            var result = CurveDataList.Find(n => n.CurveName == curveName && n.CurveDate == curveDate);
            return result;
        }

        // Create CurveData
        public void CreateCurveData(CurveData curveData)
        {
            CurveDataList.Add(curveData);
        }

        // Update CurveData by CurveName
        public CurveData UpdateCurveData(CurveData newData)
        {
            CurveData curveData = CurveDataList.Find(n => n.CurveName == newData.CurveName && n.CurveDate == newData.CurveDate);
            curveData.CurveName = newData.CurveName;
            curveData.Currency = newData.Currency;
            curveData.CurveDate = newData.CurveDate;
            curveData.CurvePoints = newData.CurvePoints;
            return curveData;
        }

        // Delete CurveData by CurveName and CurveDate
        public void DeleteCurveData(string curveName, int curveDate)
        {
            CurveData curveData = CurveDataList.Find(n => n.CurveName == curveName && n.CurveDate == curveDate);
            CurveDataList.Remove(curveData);
        }
    }
}