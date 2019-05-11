using MovieManagement.DataModels.Base;
using System.Collections.Generic;

namespace MovieManagement.DataModels
{
    public class Movie : Entity
    {
        public string Name { get; set; }

        public int Duration { get; set; }

        public string Storyline { get; set; }

        public string Director { get; set; }

        public string GenreID { get; set; }

        public Genre Genre { get; set; }

        public double Rating { get; set; }

        public int VotesCount { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<MovieActor> MovieActor { get; set; }

        public ICollection<ApplicationUserMovie> ApplicationUserMovie { get; set; }
    }
}