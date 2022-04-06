using Course_Project.Data.Models;
using Course_Project.Logic.Exceptions;
using Course_Project.Logic.Interfaces;
using Course_Project.Logic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Course_Project.Logic.Managers
{
    /// <inheritdoc cref="IFilmManager"/>
    public class FilmManager : IFilmManager
    {
        private readonly IRepositoryManager<Film> _filmRepository;

        public FilmManager(IRepositoryManager<Film> filmRepository)
        {
            _filmRepository = filmRepository ?? throw new ArgumentNullException(nameof(filmRepository));
        }

        public async Task CreateAsync(FilmDto model)
        {
            var film = new Film
            {
                Id = model.Id,
                NameFilms = model.NameFilms,
                AgeLimit = model.AgeLimit,
                ReleaseDate = model.ReleaseDate,
                Description = model.Description,
                Time = model.Time,
                PathPoster = model.PathPoster,
                ImageName = model.ImageName,
                IdRating = model.IdRating,
                RatingSite = model.RatingSite,
                RatingKinopoisk = model.RatingKinopoisk,
                RatingImdb = model.RatingImdb
            };

            await _filmRepository.CreateAsync(film);
            await _filmRepository.SaveChangesAsync();
        }

        public Task<IEnumerable<FilmDto>> GetAllByUserIdAsync(string filmId)
        {
            throw new NotImplementedException();
        }

        public Task<FilmDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
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
