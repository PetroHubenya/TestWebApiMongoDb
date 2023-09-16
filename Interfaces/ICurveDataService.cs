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
        void CreateCurveData(CurveData curveData);
        void DeleteCurveData(string curveName, int curveDate);
        List<CurveData> Read();
        CurveData ReadCurveData(string curveName, int curveDate);
        CurveData UpdateCurveData(CurveData newData);
    }
}
