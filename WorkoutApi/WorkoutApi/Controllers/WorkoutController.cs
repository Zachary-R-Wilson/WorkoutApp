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
        [HttpPost(Name = "CreateWorkout")]
        public IActionResult CreateWorkout([FromBody] WorkoutModel workoutModel)
        {
            try
            {
                _workoutService.CreateWorkout(workoutModel);
                return Ok("Workout Successfully Created");
            }
            catch (SqlException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
            }
        }
    }
}
