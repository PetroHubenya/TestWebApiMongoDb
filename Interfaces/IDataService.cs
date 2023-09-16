using Models;

namespace Interfaces
{
    public interface IDataService
    {
        Task CreateCurveDataAsync(CurveData curveData);
        Task DeleteCurveDataAsync(string curveName, int curveDate);
        Task<List<CurveData>> GetAllCurvesAsync();
        Task<CurveData> GetCurveDataAsync(string curveName, int curveDate);
        Task<CurveData> UpdateCurveDataAsync(CurveData newData);
    }
}