using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.DataModels
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ApplicationUserMovie> ApplicationUserMovie { get; set; }
    }
}
