using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Web.Shared.Models
{
    public class FilmCreateRequest
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Name.
        /// </summary>
        [Required]
        public string NameFilms { get; set; }

        /// <summary>
        /// Age limit.
        /// </summary>
        [Required]
        public int AgeLimit { get; set; }

        /// <summary>
        /// Identification rating kinopoisk.
        /// </summary>
        [Required]
        public int IdRating { get; set; }

        /// <summary>
        /// Rating kinopoisk.
        /// </summary>
        [Required]
        public string RatingKinopoisk { get; set; }

        /// <summary>
        /// Rating site.
        /// </summary>
        [Required]
        public string RatingSite { get; set; }

        /// <summary>
        /// Rating Imdb.
        /// </summary>
        [Required]
        public string RatingImdb { get; set; }

        /// <summary>
        /// Release date.
        /// </summary>
        [Required]
        public int ReleaseDate { get; set; }

        ///// <summary>
        ///// Actor.
        ///// </summary>
        //[Required]
        //public string Countries { get; set; }

        /// <summary>
        /// Actor.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        ///// <summary>
        ///// Genre.
        ///// </summary>
        //[Required]
        //public string GenreName { get; set; }

        ///// <summary>
        ///// Stage manager.
        ///// </summary>
        //[Required]
        //public string StageManagers { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Time.
        /// </summary>
        [Required]
        public int Time { get; set; }

        /// <summary>
        /// Path to file.
        /// </summary>
        [Required]
        public string PathPoster { get; set; }

        /// <summary>
        /// Image name.
        /// </summary>
        [Required]
        public string ImageName { get; set; }
    }
}
