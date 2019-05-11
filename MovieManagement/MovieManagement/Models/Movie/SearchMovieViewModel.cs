using MovieManagement.ViewModels;
using System.Collections.Generic;

namespace MovieManagement.Models.Movie
{
    public class SearchMovieViewModel
    {
        public string SearchName { get; set; }

        public IEnumerable<MovieViewModel> Movies { get; set; }
    }
}