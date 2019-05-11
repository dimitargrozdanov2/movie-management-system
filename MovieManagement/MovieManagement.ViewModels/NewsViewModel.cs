using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieManagement.ViewModels
{
    public class NewsViewModel
    {
        public string Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        public string Image { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ApplicationUser User { get; set; }
    }
}