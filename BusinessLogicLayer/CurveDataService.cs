using Interfaces;

namespace BusinessLogicLayer
{
    public class CurveDataService : ICurveDataService 
    {
        private readonly IDataService _service;

        public CurveDataService(IDataService service)
        {
            _service = service;
        }


    }
}