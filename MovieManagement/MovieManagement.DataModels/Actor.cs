using MovieManagement.DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.DataModels
{
    public class Actor : Entity
    {
        public string Name { get; set; }

        public ICollection<MovieActor> MovieActor { get; set; }
    }
}
