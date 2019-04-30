﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Areas.Administration.Models.Role
{
    public class CreateRoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
