using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WorkoutApi.Services;

namespace WorkoutApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHelloWorld()
        {
            try
            {
                return Ok("Hello World!");
            }
            catch (SqlException e)
            {
                return Ok(e.ToString());
            }
        }
    }
}
