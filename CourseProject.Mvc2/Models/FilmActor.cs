using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.Mvc2.Models
{
    [NotMapped]
    public class FilmActor
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
        /// Navigation property for Film.
        /// </summary>
        public Film Film { get; set; }

        /// <summary>
        /// Actor Identification.
        /// </summary>
        public int ActorsId { get; set; }

        /// <summary>
        /// Navigation property for Film.
        /// </summary>
        public Actor Actor { get; set; }

    }
}
