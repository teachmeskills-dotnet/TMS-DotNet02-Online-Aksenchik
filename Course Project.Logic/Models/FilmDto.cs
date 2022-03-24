using Course_Project.Data.Models;
using System;

namespace Course_Project.Logic.Models
{
    /// <summary>
    /// Film.
    /// </summary>
    public class FilmDto
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// FilmName.
        /// </summary>
        public string FilmName { get; set; }

        /// <summary>
        /// Age limit.
        /// </summary>
        public int AgeLimit { get; set; }

        /// <summary>
        /// Rating films.
        /// </summary>
        public float Rating { get; set; }

        /// <summary>
        /// Release date.
        /// </summary>
        public DateTime ReleaseDate { get; set; }
    }
}
