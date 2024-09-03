﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WorkoutApi.Services;

namespace WorkoutApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly IHelloWorldService _helloWorldService;

        public HelloWorldController(IHelloWorldService helloWorldService)
        {
            _helloWorldService = helloWorldService;
        }

        [HttpGet(Name = "GetHelloWorlds")]
        public IActionResult GetHelloWorlds()
        {
            try
            {
                var helloWorldList = _helloWorldService.GetHelloWorlds();
                return Ok(helloWorldList);
            }
            catch (SqlException e)
            {
                return Ok(e.ToString());
            }
        }
    }
}