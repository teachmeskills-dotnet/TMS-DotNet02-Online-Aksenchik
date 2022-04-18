using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Logic.Models
{
    /// <summary>
    /// Film Genre.
    /// </summary>
    public class FilmGenreDto
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Genre identification.
        /// </summary>
        public int GenreId { get; set; }

        /// <summary>
        /// Film identification.
        /// </summary>
        public int FilmId { get; set; }
    }
}
