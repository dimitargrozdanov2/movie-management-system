﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Areas.Administration.Models
{
    public class IndexViewModel
    {
        public IEnumerable<ApplicationUserViewModel> Users { get; set; }
    }
}