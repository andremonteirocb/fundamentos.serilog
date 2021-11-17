using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Fundamentos.Serilog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeriLogController : ControllerBase
    {
        private readonly ILogger<SeriLogController> _logger;
        public SeriLogController(ILogger<SeriLogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(bool exception)
        {
            try
            {
                _logger.LogInformation("Endpoint Get => WeatherForecast.Get() ");
                if (exception) throw new Exception("Ocorreu uma Exception aleatória!");

                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Endpoint Get => WeatherForecast.Get() - Exception ");
                throw;
            }
        }
    }
}
