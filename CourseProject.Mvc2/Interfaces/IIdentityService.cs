using Course_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Mvc2.Interfaces
{
    /// <summary>
    /// Identity service.
    /// </summary>
    public interface IIdentityService
    {
        /// <summary>
        /// Login.
        /// </summary>
        /// <param name="value">Object.</param>
        /// <returns>Jwt token.</returns>
        Task<(string token, IList<string> roles)> LoginAsync(object value);

        /// <summary>
        /// Register.
        /// </summary>
        /// <param name="value">Object.</param>
        /// <returns>Jwt token.</returns>
        Task<(string, string, string)> RegisterAsync(object value);
    }
}
