using Course_Project.Data.Constants;
using Course_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Course_Project.Data.Configurations
{
    /// <summary>
    /// EF Configuration for FilmStageManager entity.
    /// </summary>
    public class FilmStageManagersConfiguration : IEntityTypeConfiguration<FilmStageManager>
    {
        public void Configure(EntityTypeBuilder<FilmStageManager> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.FilmStageManagers, Schema.Film)
                .HasKey(filmStageManager => filmStageManager.Id);

            builder.Property(filmStageManager => filmStageManager.Id)
                .UseIdentityColumn();

            builder.HasOne(filmStageManager => filmStageManager.Film)
               .WithMany(film => film.FilmStageManagers)
               .HasForeignKey(filmStageManager => filmStageManager.FilmId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(filmStageManager => filmStageManager.StageManager)
                .WithMany(stageManager => stageManager.FilmStageManagers)
                .HasForeignKey(filmStageManager => filmStageManager.StageManagerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}