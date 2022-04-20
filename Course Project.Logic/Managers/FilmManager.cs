using Course_Project.Data.Models;
using Course_Project.Logic.Exceptions;
using Course_Project.Logic.Interfaces;
using Course_Project.Logic.Models;
using CourseProject.Web.Shared.Models.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_Project.Logic.Managers
{
    /// <inheritdoc cref="IFilmManager"/>
    public class FilmManager : IFilmManager
    {
        private readonly IRepositoryManager<Film> _filmRepository;
        private readonly IRepositoryManager<FilmActor> _filmActorRepository;
        private readonly IRepositoryManager<FilmCountry> _filmCountryRepository;
        private readonly IRepositoryManager<FilmGenre> _filmGenreRepository;
        private readonly IRepositoryManager<FilmStageManager> _filmStageManagerRepository;


        public FilmManager(IRepositoryManager<Film> filmRepository, 
                           IRepositoryManager<FilmActor> filmActorRepository, 
                           IRepositoryManager<FilmCountry> filmCountryRepository,
                           IRepositoryManager<FilmGenre> filmGenreRepository,
                           IRepositoryManager<FilmStageManager> filmStageManagerRepository)
        {
            _filmRepository = filmRepository ?? throw new ArgumentNullException(nameof(filmRepository));
            _filmActorRepository = filmActorRepository ?? throw new ArgumentNullException(nameof(filmActorRepository));
            _filmCountryRepository = filmCountryRepository ?? throw new ArgumentNullException(nameof(filmCountryRepository));
            _filmGenreRepository = filmGenreRepository ?? throw new ArgumentNullException(nameof(filmGenreRepository));
            _filmStageManagerRepository = filmStageManagerRepository ?? throw new ArgumentNullException(nameof(filmStageManagerRepository));
        }

        public async Task CreateAsync(FilmDto filmDto, 
            List<FilmActorDto> filmActorDto, 
            List<FilmGenreDto> filmGenreDto,
            List<FilmCountryDto> filmCountryDto,
            List<FilmStageManagerDto> filmStageManagerDto)
        {
            var film = new Film()
            {
                NameFilms = filmDto.NameFilms,
                AgeLimit = filmDto.AgeLimit,
                ReleaseDate = filmDto.ReleaseDate,
                Description = filmDto.Description,
                Time = filmDto.Time,
                PathPoster = filmDto.PathPoster,
                ImageName = filmDto.ImageName,
                IdRating = filmDto.IdRating,
                RatingSite = filmDto.RatingSite,
                RatingKinopoisk = filmDto.RatingKinopoisk,
                RatingImdb = filmDto.RatingImdb,
            };

            await _filmRepository.CreateAsync(film);
            await _filmRepository.SaveChangesAsync();

            int id = film.Id;
            foreach (var item in filmActorDto)
            {
                FilmActor filmActor = new()
                {
                    FilmId = id,
                    ActorId = item.ActorId
                };
                await _filmActorRepository.CreateAsync(filmActor);
            }

            foreach (var item in filmGenreDto)
            {
                FilmGenre filmGenre = new()
                {
                    FilmId = id,
                    GenreId = item.GenreId
                };
                await _filmGenreRepository.CreateAsync(filmGenre);
            }

            foreach (var item in filmCountryDto)
            {
                FilmCountry filmCountry = new()
                {
                    FilmId = id,
                    CountryId = item.CountryId
                };
                await _filmCountryRepository.CreateAsync(filmCountry);
            }

            foreach (var item in filmStageManagerDto)
            {
                FilmStageManager filmStageManager = new()
                {
                    FilmId = id,
                    StageManagerId = item.StageManagerId
                };
                await _filmStageManagerRepository.CreateAsync(filmStageManager);
            }
            await _filmRepository.SaveChangesAsync();
        }

            public async Task DeleteAsync(int id)
        {
            var filmDelete = await _filmRepository.GetEntityAsync(p => p.Id == id);

            if (filmDelete is null)
            {
                throw new NotFoundException($"'{nameof(id)}' project not found.", nameof(id));
            }

            _filmRepository.Delete(filmDelete);
            await _filmRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<FilmDto>> GetAllAsync()
        {
            var FilmDtos = new List<FilmDto>();

            var films = await _filmRepository
                .GetAll()
                .Select(f => new Film
                {
                    Id = f.Id,
                    NameFilms = f.NameFilms
                }).ToListAsync();

            foreach (var item in films)
            {
                FilmDtos.Add(new FilmDto
                {
                    Id = item.Id,
                    NameFilms = item.NameFilms
                });
            }
            return FilmDtos;
        }

        public async Task<FilmModelResponse> GetByIdAsync(int id)
        {
           var film = await _filmRepository.GetEntityAsync(f => f.Id == id);
            FilmModelResponse model = new()
            {
                Id = film.Id,
                NameFilms = film.NameFilms,
                PathPoster = film.PathPoster,
                ReleaseDate = film.ReleaseDate,
                AgeLimit = film.AgeLimit,
                Time = film.Time,
                Description = film.Description,
            };

            return model;
        }

        public async Task UpdateAsync(FilmDto model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));

            var filmUpdate = await _filmRepository.GetEntityAsync(p => p.Id == model.Id);

            if (filmUpdate is null)
            {
                throw new NotFoundException($"'{nameof(model.Id)}' project not found.", nameof(model.Id));
            }

            if (filmUpdate.NameFilms != model.NameFilms)
            {
                filmUpdate.NameFilms = model.NameFilms;
            }
        }
    }
}
