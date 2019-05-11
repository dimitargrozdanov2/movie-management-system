using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Infrastructure;
using MovieManagement.Services.Contracts;
using MovieManagement.Services.Exceptions;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Services
{
    public class WatchlistService : IWatchlistService
    {
        private readonly MovieManagementContext context;
        private readonly IMappingProvider mappingProvider;
        private readonly IMemoryCache cache;

        public WatchlistService(MovieManagementContext context, IMappingProvider mappingProvider, IMemoryCache cache)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mappingProvider = mappingProvider ?? throw new ArgumentNullException(nameof(mappingProvider));
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<ICollection<MovieViewModel>> GetAllMovies(string username)
        {
            var movies = await this.context.Movies
                .Include(x => x.ApplicationUserMovie)
                .Include(x => x.Genre)
                .Include(x => x.MovieActor)
                    .ThenInclude(ma => ma.Movie)
                .Where(x => x.ApplicationUserMovie.Any(u => u.User.UserName == username))
                .ToListAsync();

            var returnMovies = this.mappingProvider.MapTo<ICollection<MovieViewModel>>(movies);

            return returnMovies;
        }

        public async Task<bool> Add(string username, string movieName)
        {
            var user = await this.context.Users
                .Include(u => u.ApplicationUserMovie)
                    .ThenInclude(u => u.Movie)
                .FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                throw new EntityInvalidException($"Username '{username}' does not exist");
            }

            var movie = await this.context.Movies.FirstOrDefaultAsync(m => m.Name == movieName);

            if (movie == null)
            {
                throw new EntityInvalidException($"Movie '{movieName}' does not exist");
            }

            ApplicationUserMovie userMovie = new ApplicationUserMovie()
            {
                MovieID = movie.Id,
            };

            bool movieAlreadyInUserWL = user.ApplicationUserMovie.Any(x => x?.Movie == movie && x?.User == user);

            if (movieAlreadyInUserWL)
            {
                throw new EntityInvalidException($"Movie '{movieName} is already your watchlist!");
            }

            user.ApplicationUserMovie.Add(userMovie);
            await this.context.SaveChangesAsync();

            this.cache.Remove("Movies");

            return true;
        }

        public async Task<bool> Remove(string username, string movieName)
        {
            var user = await this.context.Users
                .Include(u => u.ApplicationUserMovie)
                    .ThenInclude(u => u.Movie)
                .FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                throw new EntityInvalidException($"Username '{username}' does not exist");
            }

            var movie = await this.context.Movies.FirstOrDefaultAsync(m => m.Name == movieName);

            if (movie == null)
            {
                throw new EntityInvalidException($"Movie '{movieName}' does not exist");
            }

            ApplicationUserMovie userMovie = movie.ApplicationUserMovie.FirstOrDefault(m => m.Movie?.Name == movieName);

            bool movieAlreadyInUserWL = user.ApplicationUserMovie.Any(x => x?.Movie == movie && x?.User == user);

            if (!movieAlreadyInUserWL)
            {
                throw new EntityInvalidException($"Movie '{movieName} is not part of your watchlist!");
            }

            user.ApplicationUserMovie.Remove(userMovie);
            await this.context.SaveChangesAsync();

            this.cache.Remove("Movies");

            return true;
        }
    }
}