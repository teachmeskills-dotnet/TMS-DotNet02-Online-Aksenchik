using System;

namespace CourseProject.Mvc2.Models
{
    public class Rating
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Rating site.
        /// </summary>
        public float RatingSite { get; set; }

        /// <summary>
        /// Rating kinopoisk.
        /// </summary>
        public float RatingKinopoisk { get; set; }

        /// <summary>
        /// Rating imdb.
        /// </summary>
        public float RRatingImdb { get; set; }
    }
}
