﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Areas.Administration.Models.News
{
    public class CreateNewsViewModel
    {
        public DateTime DatePosted { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public IFormFile Image { get; set; }
    }
}