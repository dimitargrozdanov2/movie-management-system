using MovieManagement.DataModels.Base;
using System.Collections.Generic;

namespace MovieManagement.DataModels
{
    public class News : Entity
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}