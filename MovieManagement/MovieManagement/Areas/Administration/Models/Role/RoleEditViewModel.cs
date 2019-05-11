using System.ComponentModel.DataAnnotations;

namespace MovieManagement.Areas.Administration.Models.Role
{
    public class RoleEditViewModel
    {
        [Required]
        public string OldName { get; set; }

        [Required]
        public string NewName { get; set; }
    }
}