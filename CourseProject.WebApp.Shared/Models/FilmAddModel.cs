using System;

namespace CourseProject.WebApp.Shared
{
    /// <summary>
    /// Film add model.
    /// </summary>
    public class FilmAddModel
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name.
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

        /// <summary>
        /// Actor.
        /// </summary>
        public string Countries { get; set; }

        /// <summary>
        /// Actor.
        /// </summary>
        public string Actors { get; set; }

        /// <summary>
        /// Genre.
        /// </summary>
        public string Genres { get; set; }

        /// <summary>
        /// Stage manager.
        /// </summary>
        public string StageManagers { get; set; }
    }
}
