using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Data.Models
{
    /// <summary>
    /// Country.
    /// </summary>
    public class State
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Navigation property for FilmCountries.
        /// </summary>
        public ICollection<FilmCountry> FilmCountries { get; set; }

        /// <summary>
        /// Country.
        /// </summary>
        public string Country { get; set; }
    }
}
