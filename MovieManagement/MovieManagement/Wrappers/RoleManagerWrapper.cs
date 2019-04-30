using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Wrappers
{
    public class RoleManagerWrapper : IRoleManagerWrapper
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleManagerWrapper(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        public async Task<IdentityResult> CreateRoleAsync(string name)
        {
            return await this.roleManager.CreateAsync(new IdentityRole(name));
        }

        public async Task<IdentityResult> DeleteRoleAsync(string name)
        {
            var role = await this.FindByNameAsync(name);

            if (role == null)
            {
                throw new ArgumentException("Role not found!");
            }

            return await this.roleManager.DeleteAsync(role);
        }

        public async Task<IdentityRole> FindByNameAsync(string name)
        {
            return await this.roleManager.FindByNameAsync(name);
        }

        public IQueryable<IdentityRole> GetAllRoles()
        {
            var roles = this.roleManager.Roles;

            return roles;
        }

        public async Task<IdentityResult> UpdateRoleAsync(IdentityRole role)
        {
            return await this.roleManager.UpdateAsync(role);
        }
    }
}
