using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieManagement.Areas.Administration.Models.Movie
{
    public class MovieCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string Storyline { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string GenreName { get; set; }

        public IEnumerable<SelectListItem> GenreList { get; set; }
    }
}