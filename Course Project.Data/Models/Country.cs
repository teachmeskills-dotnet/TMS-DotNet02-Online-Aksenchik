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
    public class Country
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Navigation property for FilmStageManager.
        /// </summary>
        public ICollection<FilmCountry> FilmCountries { get; set; }
        /// <summary>
        /// Actor.
        /// </summary>
        public string Countries { get; set; }
    }
}
