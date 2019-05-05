using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Infrastructure;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<MovieViewModel> CreateMovieAsync(string name, int duration,
            string storyLine, string director, string imageUrl, string genreName)
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

            var movie = new Movie() { Name = name, Genre = genre, Director = director, Duration = duration, ImageUrl = imageUrl, CreatedOn = DateTime.Now };

            await this.context.Movies.AddAsync(movie);
            await this.context.SaveChangesAsync();

            var returnMovie = this.mappingProvider.MapTo<MovieViewModel>(movie);

            return returnMovie;
        }

        public async Task<string> DeleteMovieAsync(string name)
        {
            var movie = await this.context.Movies.FirstOrDefaultAsync(m => m.Name == name);

            if (movie == null)
            {
                throw new ArgumentException($"Movie `{name}` does not exist.");
            }

            movie.IsDeleted = true;

            await this.context.SaveChangesAsync();

            return movie.Name;
        }

        public async Task<MovieViewModel> GetMovieByNameAsync(string name)
        {
            var movie = await this.context.Movies
                .Include(um => um.ApplicationUserMovie)
                    .ThenInclude(u => u.User)
                .Include(x => x.Genre)
                .Include(m => m.MovieActor)
                    .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(m => m.Name == name);

            if (movie == null)
            {
                throw new ArgumentException($"Movie `{name}` does not exist.");
            }

            var returnMovie = this.mappingProvider.MapTo<MovieViewModel>(movie);

            return returnMovie;
        }

        public async Task<ICollection<MovieViewModel>> GetTopRatedMoviesAsync()
        {
            var movies = await this.context.Movies
                .Include(um => um.ApplicationUserMovie)
                    .ThenInclude(u => u.User)
                .Include(x => x.Genre)
                .Include(x => x.MovieActor)
                    .ThenInclude(x => x.Actor)
                .OrderByDescending(x => x.Rating).ToListAsync();

            var returnMovies = this.mappingProvider.MapTo<ICollection<MovieViewModel>>(movies);

            return returnMovies;
        }

        public async Task<MovieViewModel> RateMovieAsync(string name, double rating)
        {
            var movie = await this.context.Movies.FirstOrDefaultAsync(x => x.Name == name);

            if (movie == null)
            {
                throw new ArgumentException($"Movie `{name}` does not exist.");
            }

            movie.VotesCount++;

            double currentRating = movie.Rating;
            double totalRating = currentRating * (movie.VotesCount - 1);

            totalRating += rating;

            var ratingToBeAdded = totalRating / movie.VotesCount;

            movie.Rating = double.Parse(string.Format($"{ratingToBeAdded:f1}"));

            await this.context.SaveChangesAsync();

            var returnMovie = this.mappingProvider.MapTo<MovieViewModel>(movie);

            return returnMovie;
        }

        public async Task<MovieViewModel> UpdateMovieAsync(string oldName, MovieViewModel model)
        {
            var movie = await this.context.Movies
                .Include(x => x.Genre)
                .Include(m => m.MovieActor)
                    .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(m => m.Name == oldName);

            if (movie == null)
            {
                throw new ArgumentException($"Movie `{oldName}` does not exist.");
            }

            movie.Name = model.Name;
            movie.Duration = model.Duration;
            movie.Storyline = model.Storyline;
            movie.Director = model.Director;
            movie.ImageUrl = model.ImageUrl;

            movie.ModifiedOn = DateTime.Now;

            await this.context.SaveChangesAsync();

            var returnMovie = this.mappingProvider.MapTo<MovieViewModel>(movie);

            return returnMovie;
        }

        public async Task<MovieViewModel> ManageActorAsync(string movieName, string actorName)
        {
            var movie = await this.context.Movies
               .Include(m => m.MovieActor)
                   .ThenInclude(a => a.Actor)
               .FirstOrDefaultAsync(m => m.Name == movieName);
            if (movie == null)
            {
                throw new ArgumentException($"{movieName} has not been found!");
            }

            var actor = await this.context.Actors.FirstOrDefaultAsync(a => a.Name == actorName);
            if (actor == null)
            {
                throw new ArgumentException($"{actorName} has not been found!");
            }

            // Checks whether this actor is already assigned to this movie or not.
            var isActorAlreadyAssigned = movie.MovieActor.Any(x => x.Actor == actor && x.Movie == movie);

            if (isActorAlreadyAssigned)
            {
                MovieActor actorToRemove = movie.MovieActor.FirstOrDefault(x => x.Actor?.Name == actorName);
                movie.MovieActor.Remove(actorToRemove);
            }
            else
            {
                MovieActor movieActor = new MovieActor()
                {
                    ActorId = actor.Id,
                };
                movie.MovieActor.Add(movieActor);
            }

            await this.context.SaveChangesAsync();

            var returnMovie = this.mappingProvider.MapTo<MovieViewModel>(movie);

            return returnMovie;
        }

        public async Task<ICollection<MovieViewModel>> GetLatestMoviesAsync()
        {
            var movies = await this.context.Movies
                .Include(um => um.ApplicationUserMovie)
                    .ThenInclude(u => u.User)
                .Include(x => x.Genre)
                .Include(x => x.MovieActor)
                    .ThenInclude(x => x.Actor)
                .OrderByDescending(x => x.CreatedOn).ToListAsync();

            var returnMovies = this.mappingProvider.MapTo<ICollection<MovieViewModel>>(movies);

            return returnMovies;
        }

        public async Task<ICollection<MovieViewModel>> SearchAsync(string movieName)
        {
            var movies = await this.context.Movies
                .Include(um => um.ApplicationUserMovie)
                    .ThenInclude(u => u.User)
                .Include(x => x.Genre)
                .Include(x => x.MovieActor)
                    .ThenInclude(x => x.Actor)
                .Where(m => m.Name.Contains(movieName)).ToListAsync();

            var returnMovies = this.mappingProvider.MapTo<ICollection<MovieViewModel>>(movies);

            return returnMovies;
        }
    }
}
