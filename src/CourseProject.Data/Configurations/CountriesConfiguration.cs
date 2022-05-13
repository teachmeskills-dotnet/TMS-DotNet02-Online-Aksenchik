using Course_Project.Data.Constants;
using Course_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Course_Project.Data.Configurations
{
    /// <summary>
    /// EF Configuration for Country entity.
    /// </summary>
    public class CountriesConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.States, Schema.Film)
                .HasKey(country => country.Id);

            builder.Property(country => country.Id)
                .UseIdentityColumn();

            builder.Property(country => country.Country)
               .IsRequired()
               .HasMaxLength(SqlConfiguration.SqlMaxLengthMedium);
        }
    }
}