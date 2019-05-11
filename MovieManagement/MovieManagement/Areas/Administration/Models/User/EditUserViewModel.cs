using System.ComponentModel.DataAnnotations;

namespace MovieManagement.Areas.Administration.Models.User
{
    public class EditUserViewModel
    {
        [Required]
        public string OldName { get; set; }

        [Required]
        public string NewName { get; set; }
    }
}