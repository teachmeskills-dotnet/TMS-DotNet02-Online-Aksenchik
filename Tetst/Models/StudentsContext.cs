using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tetst.Models
{
    public class StudentsContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Company> Companies { get; set; }

        public StudentsContext(DbContextOptions<StudentsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
