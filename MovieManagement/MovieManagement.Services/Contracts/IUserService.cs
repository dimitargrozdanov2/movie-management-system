using MovieManagement.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieManagement.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUserViewModel>> GetAllUsers();
    }
}