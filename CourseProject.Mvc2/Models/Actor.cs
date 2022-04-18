using System;
using System.Collections.Generic;

namespace CourseProject.Mvc2.Models
{
    public class Actor
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Second name.
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Photo path.
        /// </summary>
        public string PhotoPath { get; set; }

    }
}
