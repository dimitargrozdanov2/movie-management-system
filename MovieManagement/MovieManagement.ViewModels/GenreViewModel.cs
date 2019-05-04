﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.ViewModels
{
    public class GenreViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
