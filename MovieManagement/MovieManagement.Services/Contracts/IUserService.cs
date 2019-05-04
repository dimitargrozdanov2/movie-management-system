using MovieManagement.DataModels;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUserViewModel>> GetAllUsers();
    }
}
