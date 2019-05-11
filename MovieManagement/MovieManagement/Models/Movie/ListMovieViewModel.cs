using MovieManagement.ViewModels;
using System.Collections.Generic;

namespace MovieManagement.Models.Movie
{
    public class ListMovieViewModel
    {
        public IEnumerable<MovieViewModel> Movies { get; set; }
    }
}