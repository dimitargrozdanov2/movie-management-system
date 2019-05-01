using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Areas.Administration.Models.Movie
{
    public class CreateMovieViewModel
    {
        public string Name { get; set; }

        public int Duration { get; set; }

        public string Storyline { get; set; }

        public string Director { get; set; }

        public string GenreName { get; set; }

        public IEnumerable<SelectListItem> GenreList { get; set; }
    }
}
