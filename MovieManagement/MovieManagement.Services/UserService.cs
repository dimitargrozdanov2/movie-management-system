using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Infrastructure;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
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
        private IMappingProvider mappingProvider;

        public UserService(MovieManagementContext context, IMappingProvider mappingProvider)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mappingProvider = mappingProvider ?? throw new ArgumentNullException(nameof(mappingProvider));
        }

        public async Task<IEnumerable<ApplicationUserViewModel>> GetAllUsers()
        {
            var users = await this.context.Users.ToListAsync();

            var returnUsers = this.mappingProvider.MapTo<ICollection<ApplicationUserViewModel>>(users);

            return returnUsers;
        }
    }
}
