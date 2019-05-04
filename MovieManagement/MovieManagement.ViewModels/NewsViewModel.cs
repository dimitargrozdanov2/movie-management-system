using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.ViewModels
{
    public class NewsViewModel
    {
        public string Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }
    }
}
