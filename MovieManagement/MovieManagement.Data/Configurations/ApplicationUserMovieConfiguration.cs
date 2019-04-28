using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Data.Configurations
{
    public class ApplicationUserMovieConfiguration : IEntityTypeConfiguration<ApplicationUserMovie>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserMovie> builder)
        {
            builder
               .HasKey(um => new { um.UserID, um.MovieID });

            builder
               .HasOne(um => um.Movie)
               .WithMany(u => u.ApplicationUserMovie)
               .HasForeignKey(um => um.MovieID);

            builder
                .HasOne(um => um.User)
                .WithMany(u => u.ApplicationUserMovie)
                .HasForeignKey(um => um.UserID);
        }
    }
}
