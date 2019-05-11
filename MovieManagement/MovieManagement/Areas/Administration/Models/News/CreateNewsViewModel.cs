using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieManagement.Areas.Administration.Models.News
{
    public class CreateNewsViewModel
    {
        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public IFormFile Image { get; set; }
    }
}