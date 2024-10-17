﻿using Microsoft.AspNetCore.Authorization;
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
                var authHeader = Request.Headers["Authorization"].ToString();

                if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                {
                    return Unauthorized("Missing or invalid Authorization header.");
                }
                var token = authHeader.Substring("Bearer ".Length).Trim();

                TrackingProgressModel progress = _trackingService.GetProgress(token, DayKey);
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
                var authHeader = Request.Headers["Authorization"].ToString();

                if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                {
                    return Unauthorized("Missing or invalid Authorization header.");
                }
                var token = authHeader.Substring("Bearer ".Length).Trim();

                _trackingService.InsertTracking(token, trackingModel);
                return Ok("Progress Successfully Saved");
            }
            catch (SqlException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.ToString());
            }
        }
    }
}
