using Models;
using Interfaces;
using System.Security.Cryptography;

namespace DataAccessLayer
{
    public class FakeCurveDataService : IDataService
    {
        private List<CurveData> CurveDataList = new ()
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

        // Get all CurveData.
        public async Task<List<CurveData>> GetAllCurvesAsync()
        {
            await Task.Yield();

            return CurveDataList;
        }

        // Get CurveData by CurveName and CurveDate.
        public async Task<CurveData> GetCurveDataAsync(string curveName, int curveDate)
        {
            try
            {
                await Task.Yield();

                var result = CurveDataList.Find(n => n.CurveName == curveName && n.CurveDate == curveDate);

                if (result == null)
                {
                    throw new Exception("CurveData not found in the list.");
                }

                return result;
            }
            catch
            {
                throw;
            }
        }

        // Create CurveData.
        public async Task CreateCurveDataAsync(CurveData curveData)
        {
            try
            {
                await Task.Yield();

                if (CurveDataList.Exists(c => c._id == curveData._id))
                {
                    throw new Exception("Object with the same id already exists. Please, provide a unique id.");
                }
                else
                {
                    CurveDataList.Add(curveData);
                }
            }
            catch
            {
                throw;
            }  
        }

        // Update CurveData by CurveName (asynchronous).
        public async Task<CurveData> UpdateCurveDataAsync(CurveData newData)
        {
            try
            {
                await Task.Yield();

                CurveData? curveData = CurveDataList.Find(n => n.CurveName == newData.CurveName && n.CurveDate == newData.CurveDate);

                if (curveData == null)
                {
                    throw new Exception("CurveData not found in the list.");
                }
                else
                {
                    curveData.Currency = newData.Currency;
                    curveData.CurvePoints = newData.CurvePoints;
                }

                return curveData;
            }
            catch
            {
                throw;
            }
        }

        // Delete CurveData by CurveName and CurveDate (asynchronous).
        public async Task DeleteCurveDataAsync(string curveName, int curveDate)
        {
            try
            {
                await Task.Yield();

                CurveData? curveData = CurveDataList.Find(n => n.CurveName == curveName && n.CurveDate == curveDate);

                if (curveData == null)
                {
                    throw new Exception("CurveData not found in the list.");
                }
                else
                {
                    CurveDataList.Remove(curveData);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}