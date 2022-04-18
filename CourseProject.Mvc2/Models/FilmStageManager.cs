using System;

namespace CourseProject.Mvc2.Models
{
    public class FilmStageManager
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
        /// Stage managers Identification.
        /// </summary>
        public int StageManagersId { get; set; }
    }
}
