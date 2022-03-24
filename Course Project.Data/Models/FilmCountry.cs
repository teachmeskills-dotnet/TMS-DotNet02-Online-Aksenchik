using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Data.Models
{
    /// <summary>
    /// Film country.
    /// </summary>
    public class FilmCountry
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Country identification.
        /// </summary>
        public int CountryId { get; set; }
        /// <summary>
        /// Navigation property for country.
        /// </summary>
        public Country Country { get; set; }
        /// <summary>
        /// Film identification.
        /// </summary>
        public int FilmId { get; set; }
        /// <summary>
        /// Navigation property for Film.
        /// </summary>
        public Film Film { get; set; }
    }
}
