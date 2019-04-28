using MovieManagement.DataModels;
using MovieManagement.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Services
{
    public class MovieService : IMovieService
    {
        //private readonly MovieManagementContext context;

        public MovieService()
        {

        }

        public Task<Movie> CreateMovieAsync(string name, string genreType, string directorName, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
