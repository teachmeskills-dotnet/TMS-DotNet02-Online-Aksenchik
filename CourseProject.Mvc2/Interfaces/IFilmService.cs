using CourseProject.Web.Shared.Models.Request;
using CourseProject.Web.Shared.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseProject.Mvc2.Interfaces
{
    public interface IFilmService
    {
        /// <summary>
        /// Add film.
        /// </summary>
        /// <param name="value">Object.</param>
        /// <param name="token">Jwt token.</param>
        Task AddAsync(object value, string token);

        /// <summary>
        /// Add country.
        /// </summary>
        /// <param name="value">Object.</param>
        /// <param name="token">Jwt token.</param>
        Task AddCountryAsync(object value, string token);

        /// <summary>
        /// Get all short information films.
        /// </summary>
        /// <param name="token">Jwt token.</param>
        /// <returns>Film collection.</returns>
        Task<IEnumerable<FilmShortModelResponse>> GetAllShortAsync();

        /// <summary>
        /// Get all genre.
        /// </summary>
        /// <returns>Genre collection.</returns>
        Task<IEnumerable<GenreModelResponse>> GetAllGenreAsync();

        /// <summary>
        /// Get all country.
        /// </summary>
        /// <returns>Country collection.</returns>
        Task<IEnumerable<CountryModelResponse>> GetAllCountryAsync();

        /// <summary>
        /// Get all actor.
        /// </summary>
        /// <returns>Actor collection.</returns>
        Task<IEnumerable<ActorModelResponse>> GetAllActorAsync();

        /// <summary>
        /// Get all stage manager.
        /// </summary>
        /// <returns>Stage manager collection.</returns>
        Task<IEnumerable<StageManagerModelResponse>> GetAllStageManagerAsync();

        /// <summary>
        /// Get film by id.
        /// </summary>
        /// <returns>Film collection.</returns>
        Task<FilmModelResponse> GetByIdAsync(int id);

        /// <summary>
        /// Get random film by id.
        /// </summary>
        /// <returns>Film collection.</returns>
        Task<FilmModelResponse> GetRandomFilmByIdAsync();

        /// <summary>
        /// Get all films by name.
        /// </summary>
        /// <returns>Film collection.</returns>
        Task<FilmShortModelResponse> GetByNameAsync(string name);

        /// <summary>
        /// Get all films by genre id.
        /// </summary>
        /// <returns>Film collection.</returns>
        Task<IEnumerable<FilmShortModelResponse>> GetFilmByGenreIdAsync(int genreId);
    }
}
