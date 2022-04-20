using Course_Project.Logic.Interfaces;
using Course_Project.Logic.Models;
using CourseProject.Web.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public async Task<IActionResult> CreateAsync([FromBody] FilmCreateRequest request)
        {
            var filmActorDtos = new List<FilmActorDto>();
            var filmGenreDtos = new List<FilmGenreDto>();
            var filmCountryDtos = new List<FilmCountryDto>();
            var filmStageManagerDtos = new List<FilmStageManagerDto>();

            FilmDto filmDto = new()
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
                RatingSite = request.RatingSite,
            };

            foreach (var item in request.ActorIds)
            {
                filmActorDtos.Add(new FilmActorDto
                {
                    ActorId = item
                });
            }

            foreach (var item in request.GenreIds)
            {
                filmGenreDtos.Add(new FilmGenreDto
                {
                    GenreId = item
                });
            }

            foreach (var item in request.CountryIds)
            {
                filmCountryDtos.Add(new FilmCountryDto
                {
                    CountryId = item
                });
            }

            foreach (var item in request.StageManagerIds)
            {
                filmStageManagerDtos.Add(new FilmStageManagerDto
                {
                    StageManagerId = item
                });
            }

            if (ModelState.IsValid)
            {
               await _filmManager.CreateAsync(filmDto, 
                   filmActorDtos, 
                   filmGenreDtos, 
                   filmCountryDtos, 
                   filmStageManagerDtos);
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var film = await _filmManager.GetByIdAsync(id);

            return Ok(film);
        }

        [HttpGet("allFilms")]
        public async Task<IActionResult> GetAll()
        {
            var film = await _filmManager.GetAllAsync();

            return Ok(film);
        }

        // DELETE api/<FilmController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _filmManager.DeleteAsync(id);
        }
    }
}
