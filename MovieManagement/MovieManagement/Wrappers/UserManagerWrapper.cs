using Microsoft.AspNetCore.Identity;
using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Wrappers
{
    public class UserManagerWrapper : IUserManagerWrapper
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagerWrapper(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<ApplicationUser> FindByNameAsync(string username)
        {
           return await _userManager.FindByNameAsync(username);
        }

        // v service, posle tuk
    }
}
