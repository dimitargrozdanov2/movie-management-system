using MovieManagement.DataModels.Base;
using System.Collections.Generic;

namespace MovieManagement.DataModels
{
    public class Actor : Entity
    {
        public string Name { get; set; }

        public ICollection<MovieActor> MovieActor { get; set; }
    }
}