﻿using Course_Project.Data.Models;
using CourseProject.Web.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        Task<(IList<string> roles, string userName)> LoginAsync(object value);

        /// <summary>
        /// Register.
        /// </summary>
        /// <param name="value">Object.</param>
        /// <returns>Jwt token.</returns>
        Task<(string Email, string Password, string PasswordConfirm)> RegisterAsync(object value);

        /// <summary>
        /// Get user profile by id.
        /// </summary>
        /// <returns>Profile user.</returns>
        Task<ProfileUserResponse> GetProfileByNameAsync(string userId, string token);
    }
}
