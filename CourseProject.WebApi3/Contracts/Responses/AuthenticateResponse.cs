using Course_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.WebApi3.Contracts.Responses
{
    /// <summary>
    /// User authenticate response.
    /// </summary>
    public class AuthenticateResponse : UserAuthModel
    {
        /// <summary>
        /// Constructor with params.
        /// </summary>
        /// <param name="user">User database model.</param>
        /// <param name="token">Jwt token.</param>
        public AuthenticateResponse(User user, string token, IList<string> roles)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Token = token;
            Roles = roles;
        }
    }
}
