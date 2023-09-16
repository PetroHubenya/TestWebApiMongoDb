using Models;
using Interfaces;
using System.Security.Cryptography;

namespace DataAccessLayer
{
    public class FakeCurveDataService : IDataService
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

        // Read all (asynchronous).
        public async Task<List<CurveData>> GetAllCurvesAsync()
        {
            await Task.Yield(); // Simulate asynchronous operation.
            return CurveDataList;
        }

        // Read CurveData by CurveName and CurveDate (asynchronous).
        public async Task<CurveData> GetCurveDataAsync(string curveName, int curveDate)
        {
            await Task.Yield(); // Simulate asynchronous operation.
            var result = CurveDataList.Find(n => n.CurveName == curveName && n.CurveDate == curveDate);
            return result;
        }

        // Create CurveData (asynchronous).
        public async Task CreateCurveDataAsync(CurveData curveData)
        {
            await Task.Yield(); // Simulate asynchronous operation.
            CurveDataList.Add(curveData);
        }

        // Update CurveData by CurveName (asynchronous).
        public async Task<CurveData> UpdateCurveDataAsync(CurveData newData)
        {
            await Task.Yield(); // Simulate asynchronous operation.
            CurveData curveData = CurveDataList.Find(n => n.CurveName == newData.CurveName && n.CurveDate == newData.CurveDate);
            if (curveData != null)
            {
                curveData.Currency = newData.Currency;
                curveData.CurvePoints = newData.CurvePoints;
            }
            return curveData;
        }

        // Delete CurveData by CurveName and CurveDate (asynchronous).
        public async Task DeleteCurveDataAsync(string curveName, int curveDate)
        {
            await Task.Yield(); // Simulate asynchronous operation.
            CurveData curveData = CurveDataList.Find(n => n.CurveName == curveName && n.CurveDate == curveDate);
            if (curveData != null)
            {
                CurveDataList.Remove(curveData);
            }
        }
    }
}