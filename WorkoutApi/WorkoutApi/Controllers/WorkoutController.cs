using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WorkoutApi.Services;
using WorkoutApi.Models;

namespace WorkoutApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [Authorize]
        [HttpPost("CreateWorkout/{userKey:guid}")]
        public IActionResult CreateWorkout(Guid userKey, [FromBody] WorkoutModel workoutModel)
        {
            try
            {
                _workoutService.CreateWorkout(userKey, workoutModel);
                return Ok("Workout Successfully Created");
            }
            catch (SqlException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
            }
        }

        [Authorize]
        [HttpPost("DeleteWorkout/{workoutKey:guid}")]
        public IActionResult DeleteWorkout(Guid workoutKey)
        {
            try
            {
                _workoutService.DeleteWorkout(workoutKey);
                return Ok("Workout Successfully Deleted");
            }
            catch (SqlException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
            }
        }
    }
}
