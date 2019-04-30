using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Services.Contracts
{
    public interface IGenreService
    {
        //Genre CreateGenre(string name);

        Task<ICollection<Genre>> GetAllGenres();
    }
}
