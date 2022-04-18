using Course_Project.Data.Contexts;
using Course_Project.Data.Models;
using Course_Project.Logic.Exceptions;
using Course_Project.Logic.Interfaces;
using Course_Project.Logic.Models;
using CourseProject.Web.Shared.Models;
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
        private readonly IRepositoryManager<FilmActor> _filmactorRepository;
        private readonly IRepositoryManager<Actor> _actorRepository;
        private readonly IRepositoryManager<FilmCountry> _filmCountryRepository;
        private readonly IRepositoryManager<State> _stateRepository;
        private readonly IRepositoryManager<FilmGenre> _filmGenreRepository;
        private readonly IRepositoryManager<Genre> _genreRepository;
        private readonly IRepositoryManager<FilmStageManager> _filmStageManagerRepository;
        private readonly IRepositoryManager<StageManager> _stageManagerRepository;


        public FilmManager(IRepositoryManager<Film> filmRepository, 
                           IRepositoryManager<FilmActor> filmactorRepository, 
                           IRepositoryManager<Actor> actorRepository,
                           IRepositoryManager<FilmCountry> filmCountryRepository,
                           IRepositoryManager<State> stateRepository,
                           IRepositoryManager<FilmGenre> filmGenreRepository,
                           IRepositoryManager<Genre> genreRepository,
                           IRepositoryManager<FilmStageManager> filmStageManagerRepository,
                           IRepositoryManager<StageManager> stageManagerRepository)
        {
            _filmRepository = filmRepository ?? throw new ArgumentNullException(nameof(filmRepository));
            _filmactorRepository = filmactorRepository ?? throw new ArgumentNullException(nameof(filmactorRepository));
            _actorRepository = actorRepository ?? throw new ArgumentNullException(nameof(actorRepository));
            _filmCountryRepository = filmCountryRepository ?? throw new ArgumentNullException(nameof(filmCountryRepository));
            _stateRepository = stateRepository ?? throw new ArgumentNullException(nameof(stateRepository));
            _filmGenreRepository = filmGenreRepository ?? throw new ArgumentNullException(nameof(filmGenreRepository));
            _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
            _filmStageManagerRepository = filmStageManagerRepository ?? throw new ArgumentNullException(nameof(filmStageManagerRepository));
            _stageManagerRepository = stageManagerRepository ?? throw new ArgumentNullException(nameof(stageManagerRepository));
        }

        public async Task CreateAsync(FilmDto filmDto)
        {
            var film = new Film()
            {
                Id = filmDto.Id,
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

        public Task<IEnumerable<FilmDto>> GetAllByUserIdAsync(string filmId)
        {
            throw new NotImplementedException();
        }

        public async Task<FilmViewModel> GetByIdAsync(int id)
        {
            Film film = await _filmRepository.GetEntityAsync(p => p.Id == id);

            var filmActorId = await _filmactorRepository.GetAll().Where(x => x.FilmId == film.Id).Select(x => x.ActorId).ToListAsync();
            var filmActorFirstName = await _actorRepository.GetAll().Where(x => filmActorId.Contains(x.Id)).Select(x => x.FirstName).ToListAsync();
            var filmActorLastName = await _actorRepository.GetAll().Where(x => filmActorId.Contains(x.Id)).Select(x => x.LastName).ToListAsync();
            var filmActorSecondName = await _actorRepository.GetAll().Where(x => filmActorId.Contains(x.Id)).Select(x => x.SecondName).ToListAsync();

            var filmCountryId = await _filmCountryRepository.GetAll().Where(x => x.FilmId == film.Id).Select(x => x.CountryId).ToListAsync();
            var filmCountyNames = await _stateRepository.GetAll().Where(x => filmActorId.Contains(x.Id)).Select(x => x.Country).ToListAsync();

            var filmGenreId = await _filmGenreRepository.GetAll().Where(x => x.FilmId == film.Id).Select(x => x.GenreId).ToListAsync();
            var filmGenreNames = await _genreRepository.GetAll().Where(x => filmActorId.Contains(x.Id)).Select(x => x.Genres).ToListAsync();

            var filmStageManagerId = await _filmStageManagerRepository.GetAll().Where(x => x.FilmId == film.Id).Select(x => x.StageManagerId).ToListAsync();
            var filmstageManagerNames = await _stageManagerRepository.GetAll().Where(x => filmActorId.Contains(x.Id)).Select(x => x.StageManagers).ToListAsync();


            FilmViewModel model = new()
            {
                Id = film.Id,
                NameFilms = film.NameFilms,
                PathPoster = film.PathPoster,
                ReleaseDate = film.ReleaseDate,
                AgeLimit = film.AgeLimit,
                Time = film.Time,
                Description = film.Description,
                FirstName = filmActorFirstName,
                LastName = filmActorLastName,
                SecondName = filmActorSecondName,
                Country = filmCountyNames,
                Genre = filmGenreNames,
                StageManagers = filmstageManagerNames
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
