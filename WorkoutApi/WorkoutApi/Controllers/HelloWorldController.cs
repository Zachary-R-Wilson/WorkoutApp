using Microsoft.AspNetCore.Mvc;
using WorkoutApi.Models;
using WorkoutApi.Services;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace WorkoutApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly IHelloWorldService _service;

        public HelloWorldController(IHelloWorldService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetHelloWorlds")]
        public IActionResult GetHelloWorlds()
        {
            try
            {
                List<HelloWorld> helloWorlds = _service.GetHelloWorlds();
                return Ok(helloWorlds);
            }
            catch (SqlException e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}
