using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Services.Contracts
{
    public interface IActorService
    {
        Actor CreateActor(string name);

        Actor ChangeActorName(string currentName, string newName);
    }
}
