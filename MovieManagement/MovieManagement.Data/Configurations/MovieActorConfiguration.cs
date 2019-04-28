using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Data.Configurations
{
    class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder
                .HasKey(ma => new { ma.MovieID, ma.ActorID });

            builder
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActor)
                .HasForeignKey(ma => ma.ActorID);

            builder
               .HasOne(ma => ma.Movie)
               .WithMany(m => m.MovieActor)
               .HasForeignKey(ma => ma.MovieID);
        }
    }
}
