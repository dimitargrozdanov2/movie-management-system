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

        Task<ICollection<MovieViewModel>> GetTopRatedMovies();

        Task<MovieViewModel> GetMovieByNameAsync(string name);

        Task<MovieViewModel> RateMovie(string name, int rating);

        Task<string> DeleteMovie(string name);

        Task<MovieViewModel> UpdateMovieAsync(string oldName, MovieViewModel model);

        Task<MovieViewModel> ManageActor(string movieName, string actorName);
    }
}
