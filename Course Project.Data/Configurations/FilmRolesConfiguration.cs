using Course_Project.Data.Constants;
using Course_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Course_Project.Data.Configurations
{
    /// <summary>
    /// EF Configuration for FilmRole entity.
    /// </summary>
    public class FilmRolesConfiguration : IEntityTypeConfiguration<FilmRole>
    {
        public void Configure(EntityTypeBuilder<FilmRole> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.FilmRoles, Schema.Film)
                .HasKey(filmRole => filmRole.Id);

            builder.Property(filmRole => filmRole.Id)
                .UseIdentityColumn();

            builder.HasOne(filmRole => filmRole.Film)
               .WithMany(film => film.FilmRoles)
               .HasForeignKey(filmRole => filmRole.FilmId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(filmRole => filmRole.Actor)
                .WithMany(actor => actor.FilmRoles)
                .HasForeignKey(filmRole => filmRole.ActorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}