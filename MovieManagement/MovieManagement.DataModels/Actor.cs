using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.DataModels
{
    public class Actor
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<MovieActor> MovieActor { get; set; }
    }
}
