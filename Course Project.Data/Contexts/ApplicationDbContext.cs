using Course_Project.Data.Configurations;
using Course_Project.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Course_Project.Data.Contexts
{
    /// <summary>
    /// Main application context
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Contructor with params.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// DbSet for Films.
        /// </summary>
        public DbSet<Film> Films { get; set; }

        /// <summary>
        /// DbSet for FilmCountries.
        /// </summary>
        public DbSet<FilmCountry> FilmCountries { get; set; }

        /// <summary>
        /// DbSet for Countries.
        /// </summary>
        public DbSet<Country> Countries { get; set; }

        /// <summary>
        /// DbSet for FilmGenres.
        /// </summary>
        public DbSet<FilmGenre> FilmGenres { get; set; }

        /// <summary>
        /// DbSet for Genres.
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// DbSet for FilmRoles.
        /// </summary>
        public DbSet<FilmRole> FilmRoles { get; set; }

        /// <summary>
        /// DbSet for Actors.
        /// </summary>
        public DbSet<Actor> Actors { get; set; }

        /// <summary>
        /// DbSet for FilmStageManagers.
        /// </summary>
        public DbSet<FilmStageManager> FilmStageManagers { get; set; }

        /// <summary>
        /// DbSet for StageManagers.
        /// </summary>
        public DbSet<StageManager> StageManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ApplyConfiguration(new ActorsConfiguration());
            builder.ApplyConfiguration(new CountriesConfiguration());
            builder.ApplyConfiguration(new FilmConfiguration());
            builder.ApplyConfiguration(new FilmCountriesConfiguration());
            builder.ApplyConfiguration(new FilmGenresConfiguration());
            builder.ApplyConfiguration(new FilmRolesConfiguration());
            builder.ApplyConfiguration(new FilmStageManagersConfiguration());
            builder.ApplyConfiguration(new GenresConfiguration());
            builder.ApplyConfiguration(new StageManagersConfiguration());

            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FilmDb;Trusted_Connection=True;");
        //}
    }
}