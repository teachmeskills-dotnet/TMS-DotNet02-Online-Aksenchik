using Course_Project.Data.Constants;
using Course_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Course_Project.Data.Configurations
{
    /// <summary>
    /// EF Configuration for StageManager entity.
    /// </summary>
    public class StageManagersConfiguration : IEntityTypeConfiguration<StageManager>
    {
        public void Configure(EntityTypeBuilder<StageManager> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.StageManagers, Schema.Film)
                .HasKey(stageManager => stageManager.Id);

            builder.Property(stageManager => stageManager.Id)
                .UseIdentityColumn();
        }
    }
}