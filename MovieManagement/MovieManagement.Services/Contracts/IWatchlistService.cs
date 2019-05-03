using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Services.Contracts
{
    public interface IWatchlistService
    {
        Task<ICollection<MovieViewModel>> GetAllMovies(string username);

        Task<bool> Add(string username, string movieName);

        Task<bool> Remove(string username, string movieName);
    }
}
