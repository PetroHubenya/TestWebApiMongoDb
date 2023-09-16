using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurveDataController : ControllerBase
    {
        private readonly ICurveDataService _service;

        public CurveDataController(ICurveDataService service)
        {
            _service = service;
        }

        // Read all
        [HttpGet]
        public async Task<List<CurveData>> GetAsync()
        {
            return _service.Read();
        }

        // Read CurveData
        [HttpGet]
        public async Task<CurveData> GetCurveDataAsync(string curveName, int curveDate)
        {
            return _service.ReadCurveData(curveName, curveDate);
        }

        // Create CurveData
        [HttpPost]
        public async Task CreateCurveDataAsync(CurveData curveData)
        {
            _service.CreateCurveData(curveData);
        }

        // Update CurveData
        [HttpPut]
        public async Task<CurveData> UpdateCurveDataAsync(CurveData newData)
        {
            return _service.UpdateCurveData(newData);
        }

        // Delete CurveData
        [HttpDelete]
        public async Task DeleteCurveData(string curveName, int curveDate)
        {
            _service.DeleteCurveData(curveName, curveDate);
        }
    }
}
