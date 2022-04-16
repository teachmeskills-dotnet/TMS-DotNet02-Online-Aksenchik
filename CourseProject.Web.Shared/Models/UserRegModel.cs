using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Web.Shared.Models
{
    public class UserRegModel
    {
        /// <summary>
        /// UserName.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
