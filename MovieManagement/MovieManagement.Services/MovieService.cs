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
            this.context = context;
            this.mappingProvider = mappingProvider;
        }

        public Task<Movie> CreateMovieAsync(string name, string genreType, string directorName, int duration)
        {
            throw new NotImplementedException();
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
