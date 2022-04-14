using CourseProject.Mvc2.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace CourseProject.Mvc2.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<State> Countries { get; set; }
        public DbSet<FilmActor> FilmActors { get; set; }
        public DbSet<FilmCountry> FilmCountries { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<FilmStageManager> FilmStageManagers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<StageManager> StageManagers { get; set; }
        public DbSet<IndexViewModel> IndexViewModels { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
    }
}