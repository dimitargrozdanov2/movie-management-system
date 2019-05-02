using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Areas.Administration.Models.Movie
{
    public class MovieEditViewModel
    {
        public string OldName { get; set; }

        public string NewName { get; set; }

        public int Duration { get; set; }

        public string Storyline { get; set; }

        public string Director { get; set; }

        public string ImageUrl { get; set; }

        public string GenreName { get; set; }

        public IEnumerable<SelectListItem> GenreList { get; set; }
    }
}
