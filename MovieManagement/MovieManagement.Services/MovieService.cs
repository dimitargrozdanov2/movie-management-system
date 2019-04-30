using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Infrastructure;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieManagementContext context;
        private readonly IMappingProvider mappingProvider;

        public MovieService(MovieManagementContext context, IMappingProvider mappingProvider)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mappingProvider = mappingProvider ?? throw new ArgumentNullException(nameof(mappingProvider));
        }

        public async Task<MovieViewModel> CreateMovieAsync(string name, int duration, string storyLine, string director, string genreName)
        {
            if (await this.context.Movies.AnyAsync(m => m.Name == name))
            {
                throw new ArgumentException($"Movie with '{name}' title already exist!");
            }

            var genre = await this.context.Genres.FirstOrDefaultAsync(g => g.Name == genreName);

            if (genre == null)
            {
                throw new ArgumentException($"{genreName} genre has not been found!");
            }

            var movie = new Movie() { Name = name, Genre = genre, Director = director, Duration = duration };

            await this.context.Movies.AddAsync(movie);
            await this.context.SaveChangesAsync();

            var returnMovie = this.mappingProvider.MapTo<MovieViewModel>(movie);

            return returnMovie;
        }

        public async Task<MovieViewModel> GetMovieByNameAsync(string name)
        {
            var movie = await this.context.Movies
                .Include(m => m.MovieActor)
                    .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(m => m.Name == name);

            var returnMovie = this.mappingProvider.MapTo<MovieViewModel>(movie);

            return returnMovie;
        }

        public async Task<ICollection<MovieViewModel>> GetTopRatedMovies()
        {
            var movies = await this.context.Movies
                .Include(x => x.Genre)
                .Include(x => x.MovieActor)
                    .ThenInclude(x => x.Actor)
                .OrderByDescending(x => x.Rating).ToListAsync();

            var returnMovies = this.mappingProvider.MapTo<ICollection<MovieViewModel>>(movies);

            return returnMovies;
        }
    }
}
