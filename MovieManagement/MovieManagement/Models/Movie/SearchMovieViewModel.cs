using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Models.Movie
{
    public class SearchMovieViewModel
    {
        public string SearchName { get; set; }

        public IEnumerable<MovieViewModel> Movies { get; set; }
    }
}
