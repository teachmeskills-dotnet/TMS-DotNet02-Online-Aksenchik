﻿using Course_Project.Logic.Models;
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
        Task CreateAsync(FilmDto model);

        /// <summary>
        /// Get film by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>Film data transfer object.</returns>
        Task<FilmDto> GetByIdAsync(int id);

        /// <summary>
        /// Update film by identifier.
        /// </summary>
        /// <param name="model">film data transfer object.</param>
        Task UpdateAsync(FilmDto model);

        /// <summary>
        /// Get films by film identifier.
        /// </summary>
        /// <param name="filmId">Film identifier.</param>
        /// <returns>Film data transfer objects.</returns>
        Task<IEnumerable<FilmDto>> GetAllByUserIdAsync(string filmId);
}
