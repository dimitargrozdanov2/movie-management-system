using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.DataModels
{
    public class ApplicationUserMovie
    {
        public int MovieID { get; set; }
        public Movie Movie { get; set; }

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
    }
}
