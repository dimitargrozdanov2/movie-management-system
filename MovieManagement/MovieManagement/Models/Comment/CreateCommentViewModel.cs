using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Models.Comment
{
    public class CreateCommentViewModel
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string User {get; set;}

    }
}
