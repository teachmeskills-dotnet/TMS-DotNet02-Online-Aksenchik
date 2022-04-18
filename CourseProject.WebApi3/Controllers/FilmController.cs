using Course_Project.Logic.Interfaces;
using Course_Project.Logic.Models;
using CourseProject.Web.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CourseProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmManager _filmManager;

        public FilmController(IFilmManager filmManager)
        {
            _filmManager = filmManager ?? throw new ArgumentNullException(nameof(filmManager));
        }

        // POST api/<FilmController>
        [HttpPost("addfilm")]
        public async Task<IActionResult> CreateAsync([FromBody] FilmDto request)
        {
            var film = new FilmDto
            {
                ImageName = request.NameFilms,
                PathPoster = request.PathPoster,
                NameFilms = request.NameFilms,
                AgeLimit = request.AgeLimit,
                ReleaseDate = request.ReleaseDate,
                Time = request.Time,
                Description = request.Description,
                IdRating = request.IdRating,
                RatingImdb = request.RatingImdb,
                RatingKinopoisk = request.RatingKinopoisk,
                RatingSite = request.RatingSite
            };

            if (ModelState.IsValid)
            {
                await _filmManager.CreateAsync(film);
            }
            return Ok();

        }

        //// GET: api/<FilmController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<FilmController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var film = await _filmManager.GetByIdAsync(id);

            return Ok(film);
        }

        //// PUT api/<FilmController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<FilmController>/5
        //[HttpDelete("{id}")]
        //public async Task DeleteAsync(int id)
        //{
        //    await _filmManager.DeleteAsync(id);
        //}
    }
}
