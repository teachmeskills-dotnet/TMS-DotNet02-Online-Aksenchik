using System.ComponentModel.DataAnnotations;

namespace CourseProject.Web.Shared.Models.Request
{
    
    public class FilmSearchResponse
    {
        /// <summary>
        /// Search.
        /// </summary>
        [Required]
        public string Search { get; set; }
    }
}
