using System.ComponentModel.DataAnnotations;

namespace MovieManagement.Areas.Administration.Models
{
    public class UpdateRoleViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}