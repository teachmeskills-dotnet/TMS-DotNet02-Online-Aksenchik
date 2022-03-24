using Course_Project.Data.Models;
using Course_Project.Logic.Interfaces;
using Course_Project.Logic.Models;
using System;
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
            if (string.IsNullOrEmpty(model.FilmName))
            {
                throw new ArgumentException($"'{nameof(model.FilmName)}' cannot be null or empty.", nameof(model.FilmName));
            }

            var film = new Film
            {
                FilmName = model.FilmName,
                AgeLimit = model.AgeLimit,
                Rating = model.Rating,
                ReleaseDate = model.ReleaseDate,
            };

            await _filmRepository.CreateAsync(film);
            await _filmRepository.SaveChangesAsync();
        }

        public async Task<FilmDto> GetByIdAsync(int id)
        {
            var film = await _filmRepository.GetEntityWithoutTrackingAsync(f => f.Id == id);

            return film is null
                ? new FilmDto()
                : new FilmDto
                {
                    FilmName = film.FilmName,
                    AgeLimit = film.AgeLimit,
                    Rating = film.Rating,
                    ReleaseDate = film.ReleaseDate,
                };
        }

        public async Task UpdateAsync(FilmDto model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));

            var film = await _filmRepository.GetEntityAsync(f => f.Id == model.Id);

            if (film is null)
            {
                throw new ArgumentException($"'{nameof(model.Id)}' user not found.", nameof(model.Id));
            }

            film.FilmName = model.FilmName;
            film.AgeLimit = model.AgeLimit;
            film.Rating = model.Rating;
            film.ReleaseDate = model.ReleaseDate;

            await _filmRepository.SaveChangesAsync();
        }
    }
}
