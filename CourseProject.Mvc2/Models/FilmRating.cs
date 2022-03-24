using System;

namespace CourseProject.Mvc2.Models
{
    public class FilmRating
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Film Identification.
        /// </summary>
        public int FilmsId { get; set; }

        /// <summary>
        /// Rating Identification.
        /// </summary>
        public int RatingsId { get; set; }
    }
}
