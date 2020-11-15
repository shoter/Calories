using Microsoft.AspNetCore.Mvc;
using System;

namespace Calories.Api.Controllers
{
    [Route("api/health-check")]
    public class HealthCheckController : Controller
    {
        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok();
        }

        [HttpGet("test-exception")]
        public IActionResult TestException()
        {
            throw new Exception("Exception test");
        }
        
    }
}
