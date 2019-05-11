using System.ComponentModel.DataAnnotations;

namespace MovieManagement.Models.Comment
{
    public class CreateCommentViewModel
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string User { get; set; }
    }
}