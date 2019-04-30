using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Wrappers
{
    public interface IUserManagerWrapper
    {
        Task<ApplicationUser> FindByNameAsync(string username);
    }
}
