using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using feature_flags.features.Decisions;
using feature_flags.Features.Decisions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace feature_flags.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUseFarenheightDecider _useFarenheight;
        private readonly IChooser<int> _farenheightChooser;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
            IUseFarenheightDecider useFarenheight)
        {
            _logger = logger;
            _useFarenheight = useFarenheight;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            if(_useFarenheight.MakeDecision()) {
                // result of decision here
            }

            var x = _farenheightChooser.Choose();
            
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
