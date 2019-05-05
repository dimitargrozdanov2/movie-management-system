using Microsoft.AspNetCore.Http;
using MovieManagement.DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.DataModels
{
    public class News : Entity
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

    }
}
