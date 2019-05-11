using MovieManagement.ViewModels;
using System.Collections.Generic;

namespace MovieManagement.Models.Home
{
    public class HomeIndexViewModel
    {
        public IEnumerable<MovieViewModel> Movies { get; set; }

        public IEnumerable<NewsViewModel> News { get; set; }
    }
}