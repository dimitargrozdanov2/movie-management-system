using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.DataModels
{
    public class News
    {
        public int Id { get; set; }

        public DateTime DatePosted { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }
    }
}
