using Interfaces;
using Models;

namespace BusinessLogicLayer
{
    public class CurveDataService : ICurveDataService
    {
        private readonly IDataService _dataService;

        public CurveDataService(IDataService dataService)
        {
            _dataService = dataService;
        }

        // Read all
        public async Task<List<CurveData>> GetAllCurvesAsync()
        {
            return await _dataService.GetAllCurvesAsync();
        }

        // Read CurveData
        public async Task<CurveData> GetCurveDataAsync(string curveName, int curveDate)
        {
            return await _dataService.GetCurveDataAsync(curveName, curveDate);
        }

        // Create CurveData
        public async Task CreateCurveDataAsync(CurveData curveData)
        {
            await _dataService.CreateCurveDataAsync(curveData);
        }

        // Update CurveData
        public async Task<CurveData> UpdateCurveDataAsync(CurveData newData)
        {
            return await _dataService.UpdateCurveDataAsync(newData);
        }

        // Delete CurveData
        public async Task DeleteCurveDataAsync(string curveName, int curveDate)
        {
            await _dataService.DeleteCurveDataAsync(curveName, curveDate);
        }
    }
}