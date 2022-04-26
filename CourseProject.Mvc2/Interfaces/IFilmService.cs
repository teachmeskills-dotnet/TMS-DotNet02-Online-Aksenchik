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
        Task<IEnumerable<FilmShortModelResponse>> GetAllShortAsync(string token);

        /// <summary>
        /// Get all films.
        /// </summary>
        /// <param name="token">Jwt token.</param>
        /// <returns>Film collection.</returns>
        Task<FilmModelResponse> GetByIdAsync(int id,string token);
    }
}
