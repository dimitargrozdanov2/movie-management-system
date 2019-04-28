using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Services.Contracts
{
    public interface IGenreService
    {
        Genre CreateGenre(string name);
    }
}
