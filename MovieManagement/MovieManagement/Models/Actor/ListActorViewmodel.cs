using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Models.Actor
{
    public class ListActorViewModel
    {
        public IEnumerable<ActorViewModel> Actors { get; set; }
    }
}
