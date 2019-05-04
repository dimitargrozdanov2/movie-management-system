using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Areas.Administration.Models.Movie
{
    public class MovieManageActorsViewModel
    {
        public string MovieName { get; set; }

        [Required]
        public string ActorName { get; set; }
    }
}
