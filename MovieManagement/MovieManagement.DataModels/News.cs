﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.DataModels
{
    public class News
    {
        public string Id { get; set; }

        public DateTime DatePosted { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

    }
}
