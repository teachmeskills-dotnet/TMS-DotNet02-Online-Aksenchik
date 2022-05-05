using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Web.Shared.Models.Responses
{
    public class ProfileUserResponse
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Favourite.
        /// </summary>
        public int Favourite { get; set; }

        /// <summary>
        /// Later see.
        /// </summary>
        public int WatchLater { get; set; }
    }
}
