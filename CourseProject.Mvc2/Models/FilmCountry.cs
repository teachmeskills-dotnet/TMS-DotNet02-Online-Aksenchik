using System;

namespace CourseProject.Mvc2.Models
{
    public class FilmCountry
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Film Identification.
        /// </summary>
        public int FilmsId { get; set; }

        public Film Film { get; set; }

        /// <summary>
        /// Country Identification.
        /// </summary>
        public int CountriesId { get; set; }
        public State State { get; set; }
    }
}
