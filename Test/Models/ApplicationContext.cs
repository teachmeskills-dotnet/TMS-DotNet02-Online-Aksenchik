using Test.ViewModels;
using Test.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Test
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Phone> Phones { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}