using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Name)
                .HasMaxLength(50)
                .IsRequired();

            //builder.Property(m => m.GenreID)
            //    .IsRequired();

            builder.Property(m => m.Director)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.Duration)
                .IsRequired();
        }
    }
}
