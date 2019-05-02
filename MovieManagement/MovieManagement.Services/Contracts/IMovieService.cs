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
        //Task RateMovieAsync(string movieName, double rating);

        //Task<Movie> AssignActorAsync(string movieName, string actorName);

        //Task<Movie> UnassignActorAsync(string movieName, string actorName);

        Task<ICollection<MovieViewModel>> GetTopRatedMovies();

        Task<MovieViewModel> GetMovieByNameAsync(string name);

        Task<MovieViewModel> RateMovie(string name, double rating);

        Task<string> DeleteMovie(string name);

        Task<MovieViewModel> UpdateMovieAsync(string oldName, MovieViewModel model);
    }
}
