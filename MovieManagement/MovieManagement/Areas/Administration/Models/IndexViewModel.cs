using MovieManagement.ViewModels;
using System.Collections.Generic;

namespace MovieManagement.Areas.Administration.Models
{
    public class IndexViewModel
    {
        public IEnumerable<ApplicationUserViewModel> Users { get; set; }
    }
}