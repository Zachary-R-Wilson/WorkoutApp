using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WorkoutApi.Models;
using WorkoutApi.Services;

namespace WorkoutApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackingController : ControllerBase
    {
        private readonly ITrackingService _trackingService;

        public TrackingController(ITrackingService trackingService)
        {
            _trackingService = trackingService;
        }

        [Authorize]
        [HttpGet("GetProgress/{DayKey:guid}")]
        public IActionResult GetProgress(Guid DayKey)
        {
            try
            {
                TrackingModel progress = _trackingService.GetProgress(DayKey);
                return Ok(progress);
            }
            catch (SqlException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
            }
        }

        [Authorize]
        [HttpPost("InsertTracking")]
        public IActionResult InsertTracking([FromBody] TrackingModel trackingModel)
        {
            try
            {
                _trackingService.InsertTracking(trackingModel);
                return Ok("Progress Successfully Saved");
            }
            catch (SqlException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
            }
        }
    }
}
