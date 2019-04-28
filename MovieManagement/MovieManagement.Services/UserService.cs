using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieManagement.Services
{
    public class UserService : IUserService
    {
        private readonly MovieManagementContext context;

        public UserService(MovieManagementContext context)
        {
            this.context = context;
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            var users = this.context.Users.ToList();

            return users;
        }
    }
}
