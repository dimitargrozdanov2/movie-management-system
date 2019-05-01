using MovieManagement.DataModels;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Services.Contracts
{
    public interface IGenreService
    {
        Task<GenreViewModel> CreateGenreAsync(string name);

        Task<ICollection<Genre>> GetAllGenres();
    }
}
