using MovieManagement.DataModels;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Services.Contracts
{
    public interface IMovieService
    {
        Task<MovieViewModel> CreateMovieAsync(string name, int duration, string storyLine, string director, string imageUrl, string genreName);

        //Task<int> DeleteMovieAsync(string movieName);

        //Task RateMovieAsync(string movieName, double rating);

        //Task<Movie> AssignActorAsync(string movieName, string actorName);

        //Task<Movie> UnassignActorAsync(string movieName, string actorName);

        //Task<Movie> AddStorylineAsync(string movieName, IEnumerable<string> text);

        //Task<Movie> AddGenreAsync(string movieName, string genreName);

        //Task<Movie> FindFullMovieAsync(string movieName);

        //Task<ICollection<Movie>> GetAllMoviesFromGenreAsync(string genreName);

        //Task<ICollection<Movie>> ShowTopMoviesAsync(int amount);

        Task<ICollection<MovieViewModel>> GetTopRatedMovies();

        Task<MovieViewModel> GetMovieByNameAsync(string name);

        Task<MovieViewModel> RateMovie(string name, double rating);
    }
}
