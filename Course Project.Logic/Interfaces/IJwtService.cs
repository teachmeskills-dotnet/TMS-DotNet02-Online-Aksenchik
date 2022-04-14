using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Logic.Interfaces
{
    /// <summary>
    /// JWT service.
    /// </summary>
    public interface IJwtService
    {
        /// <summary>
        /// Generate Jwt Token.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="secret">Secret key.</param>
        string GenerateJwtToken(string userId, string secret);
    }
}
