using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Data.Models
{
    /// <summary>
    /// Stage managers.
    /// </summary>
    public class StageManager
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Navigation property for FilmStageManager.
        /// </summary>
        public ICollection<FilmStageManager> FilmStageManagers { get; set; }

        /// <summary>
        /// Stage manager.
        /// </summary>
        public string StageManagers { get; set; }
    }
}
