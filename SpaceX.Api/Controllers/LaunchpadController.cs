using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpaceX.Models;
using SpaceX.LaunchpadService;

namespace SpaceX.Api.Controllers
{
    [ApiController]
    [Route("api/launchpads")]
    public class LaunchpadController : ControllerBase
    {
        public LaunchpadController(ILogger<LaunchpadController> logger, ILaunchpadService launchpadService)
        {
            _logger = logger;
            _launchpadService = launchpadService;
        }

        private readonly ILogger<LaunchpadController> _logger;
        private readonly ILaunchpadService _launchpadService;



        [HttpGet]
        public async Task<ActionResult> Index([FromQuery(Name="limit")] int limit, [FromQuery(Name="offset")] int offset)
        {
            _logger.LogInformation("GET /api/launchpads");
            try
            {
                var result = await _launchpadService.Get(limit: limit, offset: offset);
                return new JsonResult(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error GET /api/launchpads");
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            _logger.LogInformation($"Get /api/launchpads/{id}");
            try
            {
                var result = await _launchpadService.Get(id);
                return new JsonResult(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error GET /api/launchpads/{id}");
                return BadRequest();
            }
        }
    }
}
