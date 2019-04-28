using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.DataModels
{
    public class MovieActor
    {
        public int MovieID { get; set; }
        public Movie Movie { get; set; }

        public int ActorID { get; set; }
        public Actor Actor { get; set; }
    }
}
