using Models;

namespace Interfaces
{
    public interface IDataService
    {
        List<CurveData> CreateCurveData(CurveData curveData);
        List<CurveData> DeleteCurveData(string curveName, int curveDate);
        CurveData GetCurveData(string curveName, int curveDate);
        List<CurveData> UpdateCurveData(CurveData newData);
    }
}