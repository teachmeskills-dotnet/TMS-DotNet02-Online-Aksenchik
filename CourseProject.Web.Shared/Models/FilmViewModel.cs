using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CourseProject.Web.Shared.Models
{
    public class FilmViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string NameFilms { get; set; } 

        /// <summary>
        /// Age limit.
        /// </summary>
        public int AgeLimit { get; set; }

        /// <summary>
        /// Rating kinopoisk.
        /// </summary>
        public string RatingKinopoisk { get; set; }

        /// <summary>
        /// Rating site.
        /// </summary>
        public string RatingSite { get; set; }

        /// <summary>
        /// Rating Imdb.
        /// </summary>
        public string RatingImdb { get; set; }

        /// <summary>
        /// Release date.
        /// </summary>
        public int ReleaseDate { get; set; }

        /// <summary>
        /// Actor.
        /// </summary>
        public IList<string> Country { get; set; }

        /// <summary>
        /// Actor.
        /// </summary>
        public IList<string> FirstName { get; set; }

        /// <summary>
        /// Actor.
        /// </summary>
        public IList<string> LastName { get; set; }

        /// <summary>
        /// Actor.
        /// </summary>
        public IList<string> SecondName { get; set; }

        /// <summary>
        /// Path to file.
        /// </summary>
        public string PhotoPath { get; set; }

        /// <summary>
        /// Genre.
        /// </summary>
        public IList<string> Genre { get; set; }

        /// <summary>
        /// Stage manager.
        /// </summary>
        public IList<string> StageManagers { get; set; }

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
    }
}
