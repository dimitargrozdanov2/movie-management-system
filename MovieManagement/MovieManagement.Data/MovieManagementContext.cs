﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Data.Configurations;
using MovieManagement.DataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

            this.LoadJsonFilesInDatabase(modelBuilder);

            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieActorConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserMovieConfiguration());

            modelBuilder.Entity<Movie>().HasQueryFilter(b => EF.Property<bool>(b, "IsDeleted") == false);
        }

        private void LoadJsonFilesInDatabase(ModelBuilder modelBuilder)
        {
            var genrePath = @"..\MovieManagement.Data\JsonFiles\genres.json";
            var actorsPath = @"..\MovieManagement.Data\JsonFiles\actors.json";
            var moviePath = @"..\MovieManagement.Data\JsonFiles\movies.json";
            var newsPath = @"..\MovieManagement.Data\JsonFiles\news.json";

            var userPath = @"..\MovieManagement.Data\JsonFiles\users.json";
            var rolesPath = @"..\MovieManagement.Data\JsonFiles\roles.json";
            var userRolesPath = @"..\MovieManagement.Data\JsonFiles\userRoles.json";

            var isPathFound = File.Exists(moviePath) && File.Exists(genrePath) && File.Exists(actorsPath) && File.Exists(userPath)
                && File.Exists(rolesPath) && File.Exists(userRolesPath);
            if (isPathFound)
            {
                var genres = JsonConvert.DeserializeObject<Genre[]>(File.ReadAllText(genrePath));
                var movies = JsonConvert.DeserializeObject<Movie[]>(File.ReadAllText(moviePath));
                var actors = JsonConvert.DeserializeObject<Actor[]>(File.ReadAllText(actorsPath));
                var news = JsonConvert.DeserializeObject<News[]>(File.ReadAllText(newsPath));

                var users = JsonConvert.DeserializeObject<ApplicationUser[]>(File.ReadAllText(userPath));
                var roles = JsonConvert.DeserializeObject<IdentityRole[]>(File.ReadAllText(rolesPath));
                var userRoles = JsonConvert.DeserializeObject<IdentityUserRole<string>[]>(File.ReadAllText(userRolesPath));

                modelBuilder.Entity<Genre>().HasData(genres);
                modelBuilder.Entity<Movie>().HasData(movies);
                modelBuilder.Entity<Actor>().HasData(actors);
                modelBuilder.Entity<News>().HasData(news);

                modelBuilder.Entity<ApplicationUser>().HasData(users);
                modelBuilder.Entity<IdentityRole>().HasData(roles);
                modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            }
        }
    }
}