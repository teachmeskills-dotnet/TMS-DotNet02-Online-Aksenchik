using System.ComponentModel.DataAnnotations;

namespace CourseProject.Web.Shared.Models.Request
{
    public class StageManagerCreateRequest
    {
        /// <summary>
        /// StageManager.
        /// </summary>
        [Required]
        public string StageManager { get; set; }
    }
}
