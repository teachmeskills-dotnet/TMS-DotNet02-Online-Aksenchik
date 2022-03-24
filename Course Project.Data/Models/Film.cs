using System;
using System.Collections.Generic;
using System.Linq;

namespace Course_Project.Data.Models
{
    /// <summary>
    /// Film.
    /// </summary>
    public class Film
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Navigation property for FilmStageManager.
        /// </summary>
        public ICollection<FilmStageManager> FilmStageManagers { get; set; }

        /// <summary>
        /// Navigation property for FilmRoles.
        /// </summary>
        public ICollection<FilmRole> FilmRoles { get; set; }

        /// <summary>
        /// Navigation property for FilmCountry.
        /// </summary>
        public ICollection<FilmCountry> FilmCountries { get; set; }

        /// <summary>
        /// Navigation property for FilmGenre.
        /// </summary>
        public ICollection<FilmGenre> FilmGenres { get; set; }

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
