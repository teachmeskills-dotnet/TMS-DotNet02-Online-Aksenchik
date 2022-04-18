using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Logic.Models
{
    /// <summary>
    /// Film country.
    /// </summary>
    public class FilmCountryDto
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
        /// Film identification.
        /// </summary>
        public int FilmId { get; set; }
    }
}
