using Models;
using System.Security.Cryptography;

namespace DataAccessLayer
{
    public class FakeCurveData
    {
        private CurveData CurveObject = new CurveData()
        {
            _id = "idString",
            CurveName = "CurveName",
            Currency = "CAD",
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

        };

    }
}