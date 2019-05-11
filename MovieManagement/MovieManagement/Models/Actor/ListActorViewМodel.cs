using MovieManagement.ViewModels;
using System.Collections.Generic;

namespace MovieManagement.Models.Actor
{
    public class ListActorViewModel
    {
        public IEnumerable<ActorViewModel> Actors { get; set; }
    }
}