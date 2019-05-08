﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieManagement.ViewModels
{
    public class MovieViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string Storyline { get; set; }

        [Required]
        public string Director { get; set; }

        public string Genre { get; set; }

        public double Rating { get; set; }

        public int VotesCount { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public ICollection<string> Actors { get; set; }

        public ICollection<string> Users { get; set; }
    }
}
