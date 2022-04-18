using Course_Project.Data.Constants;
using Course_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Data.Configurations
{
    /// <summary>
    /// EF Configuration for Film entity.
    /// </summary>
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.Films, Schema.Film)
                .HasKey(film => film.Id);

            builder.Property(film => film.Id)
                .UseIdentityColumn();

            builder.Property(film => film.RatingSite)
               .IsRequired()
               .HasMaxLength(SqlConfiguration.SqlMaxLengthShort);

            builder.Property(film => film.RatingKinopoisk)
               .IsRequired()
               .HasMaxLength(SqlConfiguration.SqlMaxLengthShort);

            builder.Property(film => film.RatingImdb)
               .IsRequired()
               .HasMaxLength(SqlConfiguration.SqlMaxLengthShort);
        }
    }
}
