using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Areas.Administration.Models.Role
{
    public class RoleIndexViewModel
    {
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
