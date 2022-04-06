using Course_Project.Data.Models;
using Course_Project.Logic.Interfaces;
using Course_Project.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IFilmManager _filmManager;
        private readonly ILogger<WeatherForecastController> _logger;
        

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IFilmManager filmManager)
        {
            _logger = logger;
            _filmManager = filmManager ?? throw new ArgumentNullException(nameof(filmManager));
        }

        [HttpGet]
        public async Task CreateAsync()
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
        }
    }
}
