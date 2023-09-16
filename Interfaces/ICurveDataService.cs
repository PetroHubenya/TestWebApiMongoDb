using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICurveDataService
    {
        Task CreateCurveDataAsync(CurveData curveData);
        Task DeleteCurveDataAsync(string curveName, int curveDate);
        Task<List<CurveData>> GetAllCurvesAsync();
        Task<CurveData> GetCurveDataAsync(string curveName, int curveDate);
        Task<CurveData> UpdateCurveDataAsync(CurveData newData);
    }
}
