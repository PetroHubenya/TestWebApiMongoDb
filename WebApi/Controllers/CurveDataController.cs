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
        public async Task<ActionResult<List<CurveData>>> GetAllCurvesAsync()
        {
            var result = _service.GetAllCurves();
            if (result == null)
            {
                return NotFound("CurveData objects not found.");
            }
            return Ok(result);
        }

        // Read CurveData
        [HttpGet("{curveName}/{curveDate}")]
        public async Task<ActionResult<CurveData>> GetCurveDataAsync(string curveName, int curveDate)
        {
            var result = _service.GetCurveData(curveName, curveDate);
            if (result == null)
            {
                return NotFound("CurveData not found.");
            }
            return Ok(result);
        }

        // Create CurveData
        [HttpPost]
        public async Task<IActionResult> CreateCurveDataAsync(CurveData curveData)
        {
            _service.CreateCurveData(curveData);
            return Ok("CurveData created.");
        }

        // Update CurveData
        [HttpPut]
        public async Task<ActionResult<CurveData>> UpdateCurveDataAsync(CurveData newData)
        {
            var result = _service.UpdateCurveData(newData);
            if (result == null)
            {
                return NotFound("CurveData not found.");
            }
            return Ok(result);
        }

        // Delete CurveData
        [HttpDelete]
        public async Task<IActionResult> DeleteCurveDataAsync(string curveName, int curveDate)
        {
            _service.DeleteCurveData(curveName, curveDate);
            return Ok("CurveData deleted.");
        }
    }
}
