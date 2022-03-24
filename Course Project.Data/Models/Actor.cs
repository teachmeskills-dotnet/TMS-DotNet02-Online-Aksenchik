using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Data.Models
{
    /// <summary>
    /// Film actor.
    /// </summary>
    public class Actor
    {
        /// <summary>
        /// Identification
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Navigation property for FilmStageManager.
        /// </summary>
        public ICollection<FilmRole> FilmRoles { get; set; }
        /// <summary>
        /// Actor.
        /// </summary>
        public string Actors { get; set; }
    }
}
