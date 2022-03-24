using Course_Project.Logic.Interfaces;
using Course_Project.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_Project.WebApi.Controllers
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
        private readonly IFilmManager _filmManager;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IFilmManager filmManager)
        {
            _logger = logger;
            _filmManager = filmManager ?? throw new ArgumentNullException(nameof(filmManager));
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            var filmTest = new FilmDto
            {
                FilmName = "Test",
                AgeLimit = 12,
                Rating = 9.1f,
            };

            await _filmManager.CreateAsync(filmTest);

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
