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
        public List<CurveData> Read()
        {
            return _dataService.Read();
        }

        // Read CurveData
        public CurveData ReadCurveData(string curveName, int curveDate)
        {
            return _dataService.ReadCurveData(curveName, curveDate);
        }

        // Create CurveData
        public void CreateCurveData(CurveData curveData)
        {
            _dataService.CreateCurveData(curveData);
        }

        // Update CurveData
        public CurveData UpdateCurveData(CurveData newData)
        {
            return _dataService.UpdateCurveData(newData);
        }

        // Delete CurveData
        public void DeleteCurveData(string curveName, int curveDate)
        {
            _dataService.DeleteCurveData(curveName, curveDate);
        }

    }
}