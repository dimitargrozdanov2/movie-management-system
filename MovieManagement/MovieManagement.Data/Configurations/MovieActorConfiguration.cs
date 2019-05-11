using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieManagement.DataModels;

namespace MovieManagement.Data.Configurations
{
    internal class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder
                .HasKey(ma => new { ma.MovieId, ma.ActorId });

            builder
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActor)
                .HasForeignKey(ma => ma.ActorId);

            builder
               .HasOne(ma => ma.Movie)
               .WithMany(m => m.MovieActor)
               .HasForeignKey(ma => ma.MovieId);
        }
    }
}