using Course_Project.Logic.Interfaces;
using Course_Project.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.WebApi3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IFilmManager _filmManager;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IFilmManager filmManager)
        {
            _logger = logger;
            _filmManager = filmManager ?? throw new ArgumentNullException(nameof(filmManager));
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            var filmTest = new FilmDto
            {
                NameFilms = "test",
                AgeLimit = 12,
                ReleaseDate = 2222,
                Description = "test",
                Time = 111,
                PathPoster = "test",
                ImageName = "test",
                IdRating = 2,
                RatingSite = "test",
                RatingKinopoisk = "test",
                RatingImdb = "test"
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

        //[HttpGet]
        //public async Task CreateAsync()
        //{
        //    var filmTest = new FilmDto
        //    {
        //        NameFilms = "test",
        //        AgeLimit = 12,
        //        ReleaseDate = 2222,
        //        Description = "test",
        //        Time = 111,
        //        PathPoster = "test",
        //        ImageName = "test",
        //        IdRating = 2,
        //        RatingSite = "test",
        //        RatingKinopoisk = "test",
        //        RatingImdb = "test"
        //    };

        //    await _filmManager.CreateAsync(filmTest);
        //}
    }
}
