using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Data.Models
{
    public class UserFilm
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User identification.
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Navigation property for user.
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Film identification.
        /// </summary>
        public int FilmId { get; set; }
        /// <summary>
        /// Navigation property for Film.
        /// </summary>
        public Film Film { get; set; }
    }
}
