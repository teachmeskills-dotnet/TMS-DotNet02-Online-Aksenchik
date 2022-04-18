using Course_Project.Logic.Models;
using CourseProject.Web.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Logic.Interfaces
{
    /// <summary>
    /// Film manager.
    /// </summary>
    public interface IFilmManager
    {
        /// <summary>
        /// Create film.
        /// </summary>
        /// <param name="model">film data transfer object.</param>
        Task CreateAsync(FilmDto filmDto, ActorDto actorDto);

        /// <summary>
        /// Get film by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>Film data transfer object.</returns>
        Task<FilmViewModel> GetByIdAsync(int id);

        /// <summary>
        /// Update film by identifier.
        /// </summary>
        /// <param name="model">film data transfer object.</param>
        Task UpdateAsync(FilmDto model);

        /// <summary>
        /// Delete film by identifier.
        /// </summary>
        /// <param name="id">Film identifier.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Get films by film identifier.
        /// </summary>
        /// <param name="filmId">Film identifier.</param>
        /// <returns>Film data transfer objects.</returns>
        Task<IEnumerable<FilmDto>> GetAllByUserIdAsync(string filmId);
    }
}
