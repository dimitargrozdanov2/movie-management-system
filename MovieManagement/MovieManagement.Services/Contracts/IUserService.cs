using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Services.Contracts
{
    public interface IUserService
    {
        //User CreateUser(string name);

        //User PrintUserInfo(string userName);

        //User AddMovietoUserWatchlist(string movieName, string userName);

        //User RemoveMoviefromUserWatchlist(string movieName, string userName);

        //ICollection<string> ShowAllMoviesfromWatchlist(string userName);

        Task<IEnumerable<ApplicationUser>> GetAllUsers();
    }
}
