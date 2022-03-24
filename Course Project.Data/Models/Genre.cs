using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Data.Models
{
    /// <summary>
    /// Genre.
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Navigation property for FilmGenre.
        /// </summary>
        public ICollection<FilmGenre> FilmGenres { get; set; }

        /// <summary>
        /// Genre.
        /// </summary>
        public string Genres { get; set; }
    }
}
