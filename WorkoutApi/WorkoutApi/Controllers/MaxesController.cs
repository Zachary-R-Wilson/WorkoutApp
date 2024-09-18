using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WorkoutApi.Models;
using WorkoutApi.Services;

namespace WorkoutApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaxesController : ControllerBase
    {

        private readonly IMaxesService _maxesService;

        public MaxesController(IMaxesService maxesService)
        {
            _maxesService = maxesService;
        }

        [Authorize]
        [HttpGet("GetMaxes/{userKey:guid}")]
        public IActionResult GetProgress(Guid userKey)
        {
            try
            {
                MaxModel progress = _maxesService.GetMaxes(userKey);
                return Ok(progress);
            }
            catch (SqlException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
            }
        }

        [Authorize]
        [HttpPost("UpdateMaxes/{userKey:guid}")]
        public IActionResult UpdateMaxes(Guid userKey, [FromBody] MaxModel maxModel)
        {
            try
            {
                _maxesService.UpdateMaxes(userKey, maxModel);
                return Ok("Maxes Successfully Updated");
            }
            catch (SqlException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
            }
        }
    }
}
