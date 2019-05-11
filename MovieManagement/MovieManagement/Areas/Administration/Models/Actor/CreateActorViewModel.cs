using System.ComponentModel.DataAnnotations;

namespace MovieManagement.Areas.Administration.Models.Actor
{
    public class CreateActorViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}