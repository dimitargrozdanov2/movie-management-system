using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Areas.Administration.Models.Actor
{
    public class CreateActorViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
