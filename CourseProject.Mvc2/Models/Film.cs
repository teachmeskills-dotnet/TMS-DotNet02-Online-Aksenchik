using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.Mvc2.Models
{
    public class Film
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identification rating kinopoisk.
        /// </summary>
        public int IdRating { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string NameFilms { get; set; }

        /// <summary>
        /// Age limit.
        /// </summary>
        public int AgeLimit { get; set; }

        /// <summary>
        /// Release date.
        /// </summary>
        public int ReleaseDate { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Time.
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Path to file.
        /// </summary>
        public string PathPoster { get; set; }

        /// <summary>
        /// Image name.
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Rating site.
        /// </summary>
        public string RatingSite { get; set; }

        /// <summary>
        /// Rating kinopoisk.
        /// </summary>
        public string RatingKinopoisk { get; set; }

        /// <summary>
        /// Rating imdb.
        /// </summary>
        public string RatingImdb { get; set; }

        public List<State> States { get; set; } = new();

        public List<FilmCountry> FilmCountries { get; set; } = new();
    }
}
