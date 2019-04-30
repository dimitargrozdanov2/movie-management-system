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
        private readonly UserManager<ApplicationUser> userManager;

        public UserManagerWrapper(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<ApplicationUser> FindByNameAsync(string username)
        {
           return await userManager.FindByNameAsync(username);
        }

        public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role)
        {
            return await this.userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
        {
            return await this.userManager.UpdateAsync(user);
        }

        // first do in service, then comes here, as it is a manager, not service.
    }
}
