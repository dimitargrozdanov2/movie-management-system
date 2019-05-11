using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MovieManagement.Areas.Administration.Models.Role
{
    public class RoleIndexViewModel
    {
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}