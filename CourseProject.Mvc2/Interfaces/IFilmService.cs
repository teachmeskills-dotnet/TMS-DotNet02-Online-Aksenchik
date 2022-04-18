﻿using System.Threading.Tasks;

namespace CourseProject.Mvc2.Interfaces
{
    public interface IFilmService
    {
        /// <summary>
        /// Add record.
        /// </summary>
        /// <param name="value">Object.</param>
        /// <param name="token">Jwt token.</param>
        Task AddAsync(object value, string token);
    }
}
