﻿using Microsoft.AspNetCore.Identity;
using MovieManagement.DataModels;
using System.Threading.Tasks;

namespace MovieManagement.Wrappers
{
    public interface IUserManagerWrapper
    {
        Task<ApplicationUser> FindByNameAsync(string username);

        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);

        Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
    }
}