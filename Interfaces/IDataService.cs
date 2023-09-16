using Models;

namespace Interfaces
{
    public interface IDataService
    {
        void CreateCurveData(CurveData curveData);
        void DeleteCurveData(string curveName, int curveDate);
        List<CurveData> Read();
        CurveData ReadCurveData(string curveName, int curveDate);
        CurveData UpdateCurveData(CurveData newData);
    }
}