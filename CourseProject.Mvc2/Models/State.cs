using System;
using System.Collections.Generic;

namespace CourseProject.Mvc2.Models
{
    public class State
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Country.
        /// </summary>
        public string Country { get; set; }

        public List<Film> Films { get; set; } = new();

        public List<FilmCountry> FilmCountries { get; set; } = new();
    }
}
