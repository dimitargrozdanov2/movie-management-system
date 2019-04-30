using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.ViewModels
{
    public class MovieViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Duration { get; set; }

        public string Storyline { get; set; }

        public string Director { get; set; }

        public string Genre { get; set; }

        public double Rating { get; set; }

        public int VotesCount { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<string> Actors { get; set; }
    }
}
