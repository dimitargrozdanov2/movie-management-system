using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Services
{
    public class UserService : IUserService
    {
        private readonly MovieManagementContext context;

        public UserService(MovieManagementContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            var users = await this.context.Users.ToListAsync();

            return users;
        }
    }
}
