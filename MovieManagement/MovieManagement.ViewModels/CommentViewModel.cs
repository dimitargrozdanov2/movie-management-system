using System;

namespace MovieManagement.ViewModels
{
    public class CommentViewModel
    {
        public string Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string Text { get; set; }
    }
}