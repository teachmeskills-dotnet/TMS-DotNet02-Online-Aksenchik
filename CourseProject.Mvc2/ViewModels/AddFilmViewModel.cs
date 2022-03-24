using System.ComponentModel.DataAnnotations;

namespace CourseProject.Mvc2.ViewModels
{
    public class AddFilmViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [Required]
        public string FilmName { get; set; }

        /// <summary>
        /// Age limit.
        /// </summary>
        [Required]
        public int AgeLimit { get; set; }

        /// <summary>
        /// Rating kinopoisk.
        /// </summary>
        [Required]
        public string RatingKinopoisk { get; set; }

        /// <summary>
        /// Rating site.
        /// </summary>
        [Required]
        public string Rating { get; set; }

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

        /// <summary>
        /// Actor.
        /// </summary>
        [Required]
        public string Countries { get; set; }

        /// <summary>
        /// Actor.
        /// </summary>
        [Required]
        public string Actors { get; set; }

        /// <summary>
        /// Genre.
        /// </summary>
        [Required]
        public string GenreName { get; set; }

        /// <summary>
        /// Stage manager.
        /// </summary>
        [Required]
        public string StageManagers { get; set; }

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
