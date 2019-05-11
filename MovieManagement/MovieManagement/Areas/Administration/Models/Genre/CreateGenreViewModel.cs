using System.ComponentModel.DataAnnotations;

namespace MovieManagement.Areas.Administration.Models.Genre
{
    public class CreateGenreViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}