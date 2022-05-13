using System.ComponentModel.DataAnnotations;

namespace CourseProject.Web.Shared.Models.Request
{
    public class CountryCreateRequest
    {
        /// <summary>
        /// Country.
        /// </summary>
        [Required]
        public string Country { get; set; }
    }
}