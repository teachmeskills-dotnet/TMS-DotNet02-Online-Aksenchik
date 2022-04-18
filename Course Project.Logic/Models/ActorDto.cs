using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Logic.Models
{
    /// <summary>
    /// Film actor.
    /// </summary>
    public class ActorDto
    {
        /// <summary>
        /// Identification
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Second name.
        /// </summary>
        public string SecondName { get; set; }
    }
}
