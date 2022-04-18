using System;

namespace CourseProject.Mvc2.Models
{
    public class FilmGenre
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
        /// Genre Identification.
        /// </summary>
        public int GenresID { get; set; }
    }
}
