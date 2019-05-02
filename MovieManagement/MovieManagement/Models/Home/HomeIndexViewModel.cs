using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Models.Home
{
    public class HomeIndexViewModel
    {
        public IEnumerable<MovieViewModel> Movies { get; set; }

    }
}
