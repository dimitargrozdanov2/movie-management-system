using System.ComponentModel.DataAnnotations;

namespace MovieManagement.Areas.Administration.Models.Movie
{
    public class MovieManageActorsViewModel
    {
        public string MovieName { get; set; }

        [Required]
        public string ActorName { get; set; }
    }
}