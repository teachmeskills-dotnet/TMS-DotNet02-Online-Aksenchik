using Microsoft.AspNetCore.Identity;

namespace CourseProject.Mvc2.Models
{
    public class User: IdentityUser
    {
        public int Favourite { get; set; }
        public int LaterSee { get; set; }
    }
}
