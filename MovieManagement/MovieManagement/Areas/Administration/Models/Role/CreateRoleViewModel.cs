using System.ComponentModel.DataAnnotations;

namespace MovieManagement.Areas.Administration.Models.Role
{
    public class CreateRoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}