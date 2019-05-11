using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MovieManagement.DataModels
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ApplicationUserMovie> ApplicationUserMovie { get; set; }
    }
}