using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutroRestfull.Controllers
{
    /// <summary>
    /// Serviços sobre o Tempo
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Mostra o tempo em todas as cidades
        /// </summary>
        /// <returns>Time Date</returns>
        /// <response code="200">Success</response>
        /// <response code="400">City unknown</response>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Get Data from a particular City
        /// </summary>
        /// <param name="i"></param>
        /// <returns>Time Date of a particular city</returns>
        /// <response code="200">Success</response>
        /// <response code="400">City unknown</response>
        [HttpGet("{i}")]
        [ProducesResponseType(typeof(WeatherForecast), 200)]
        [ProducesResponseType(typeof(IDictionary<string,string>), 400)]
        public string GetCitySummary(int i)
        {
            if (i < 7)
                return Summaries[i];
            else
                return "";
        }
    }
}
