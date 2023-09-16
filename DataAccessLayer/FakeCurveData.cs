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

        // Read CurveData by CurveName and CurveDate
        public CurveData GetCurveData(string curveName, int curveDate)
        {
            var result = CurveDataList.Find(n => n.CurveName == curveName && n.CurveDate == curveDate);
            return result;
        }

        // Create CurveData by CurveName
        public List<CurveData> CreateCurveData(CurveData curveData)
        {
            CurveDataList.Add(curveData);
            return CurveDataList;
        }

        // Update CurveData by CurveName
        public List<CurveData> UpdateCurveData(CurveData newData)
        {
            CurveData oldCurveData = CurveDataList.Find(n => n.CurveName == newData.CurveName && n.CurveDate == newData.CurveDate);
            oldCurveData.CurveName = newData.CurveName;
            oldCurveData.Currency = newData.Currency;
            oldCurveData.CurveDate = newData.CurveDate;
            oldCurveData.CurvePoints = newData.CurvePoints;
            return CurveDataList;
        }

        // Delete CurveData by CurveName and CurveDate
        public List<CurveData> DeleteCurveData(string curveName, int curveDate)
        {
            CurveData curveData = CurveDataList.Find(n => n.CurveName == curveName && n.CurveDate == curveDate);
            CurveDataList.Remove(curveData);
            return CurveDataList;
        }








    }
}