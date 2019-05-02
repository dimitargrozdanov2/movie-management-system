using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MovieManagement.Areas.Administration.Models.Movie
{
    public class MovieCreateViewModel
    {
        public string Name { get; set; }

        public int Duration { get; set; }

        public string Storyline { get; set; }

        public string Director { get; set; }

        public string ImageUrl { get; set; }

        public string GenreName { get; set; }

        public IEnumerable<SelectListItem> GenreList { get; set; }
    }
}
