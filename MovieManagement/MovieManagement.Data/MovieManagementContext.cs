using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Data.Configurations;
using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Data
{
    public class MovieManagementContext : IdentityDbContext<ApplicationUser>
    {
        public MovieManagementContext(DbContextOptions<MovieManagementContext> options)
            :base (options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<MovieActor> MovieActor { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<ApplicationUserMovie> UserMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieActorConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserMovieConfiguration());

            modelBuilder.Entity<Movie>().HasQueryFilter(b => EF.Property<bool>(b, "IsDeleted") == false);
        }
    }
}
