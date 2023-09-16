using Models;

namespace Interfaces
{
    public interface IDataService
    {
        void CreateCurveData(CurveData curveData);
        void DeleteCurveData(string curveName, int curveDate);
        List<CurveData> GetAllCurves();
        CurveData GetCurveData(string curveName, int curveDate);
        CurveData UpdateCurveData(CurveData newData);
    }
}