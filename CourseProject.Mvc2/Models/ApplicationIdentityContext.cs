using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Mvc2.Models
{
    public class ApplicationIdentityContext : IdentityDbContext<User>
    {
        public ApplicationIdentityContext(DbContextOptions<ApplicationIdentityContext> options)
            : base(options)
        {
        }
    }
}
