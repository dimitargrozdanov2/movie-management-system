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
        Task<MovieViewModel> CreateMovieAsync(string name, int duration, string storyline, string director, string imageUrl, string genreName);

        Task<ICollection<MovieViewModel>> GetTopRatedMoviesAsync();

        Task<ICollection<MovieViewModel>> GetLatestMoviesAsync();

        Task<MovieViewModel> GetMovieByNameAsync(string name);

        Task<MovieViewModel> RateMovieAsync(string name, double rating);

        Task<string> DeleteMovieAsync(string name);

        Task<MovieViewModel> UpdateMovieAsync(string oldName, MovieViewModel model);

        Task<MovieViewModel> ManageActorAsync(string movieName, string actorName);

        Task<ICollection<MovieViewModel>> SearchAsync(string movieName);
    }
}
