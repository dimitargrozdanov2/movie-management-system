using MovieManagement.DataModels;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Services.Contracts
{
    public interface IActorService
    {
        Task<ActorViewModel> ChangeActorNameAsync(string currentName, ActorViewModel model);

        Task<ActorViewModel> CreateActorAsync(string name);

        Task<ICollection<ActorViewModel>> GetAllActorsAsync();

        Task<ActorViewModel> GetActorByNameAsync(string name);

    }
}
