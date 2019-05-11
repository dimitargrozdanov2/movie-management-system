using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Infrastructure;
using MovieManagement.Services.Contracts;
using MovieManagement.Services.Exceptions;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Services
{
    public class ActorService : IActorService
    {
        private readonly MovieManagementContext context;
        private readonly IMappingProvider mappingProvider;

        public ActorService(MovieManagementContext context, IMappingProvider mappingProvider)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mappingProvider = mappingProvider ?? throw new ArgumentNullException(nameof(mappingProvider));
        }

        public async Task<ActorViewModel> CreateActorAsync(string name)
        {
            if (await this.context.Actors.AnyAsync(m => m.Name == name))
            {
                throw new EntityAlreadyExistsException($"Actor with '{name}' name already exist!");
            }

            var actor = new Actor() { Name = name, CreatedOn = DateTime.Now };

            await this.context.Actors.AddAsync(actor);

            await this.context.SaveChangesAsync();

            var returnActor = this.mappingProvider.MapTo<ActorViewModel>(actor);

            return returnActor;
        }

        public async Task<ActorViewModel> ChangeActorNameAsync(string currentName, ActorViewModel model)
        {
            bool nameExists = await this.context.Actors.AnyAsync(n => n.Name == currentName);
            if (nameExists == false)
            {
                throw new EntityInvalidException($"Actor with '{currentName}' name does not exist!");
            }

            var actor = await this.context.Actors.FirstOrDefaultAsync(a => a.Name == currentName);

            actor.Name = model.Name;
            actor.ModifiedOn = DateTime.Now;

            await this.context.SaveChangesAsync();

            var returnActor = this.mappingProvider.MapTo<ActorViewModel>(actor);

            return returnActor;
        }

        public async Task<ActorViewModel> DeleteActorAsync(string currentName)
        {
            bool nameExists = await this.context.Actors.AnyAsync(n => n.Name == currentName);
            if (nameExists == false)
            {
                throw new EntityInvalidException($"Actor with '{currentName}' name does not exist!");
            }

            var actor = await this.context.Actors.FirstOrDefaultAsync(a => a.Name == currentName);

            this.context.Actors.Remove(actor);

            await this.context.SaveChangesAsync();

            var returnActor = this.mappingProvider.MapTo<ActorViewModel>(actor);

            return returnActor;
        }

        public async Task<ICollection<ActorViewModel>> GetAllActorsAsync()
        {
            var actors = await this.context.Actors.OrderBy(x => x.Name).ToListAsync();

            var returnActors = this.mappingProvider.MapTo<ICollection<ActorViewModel>>(actors);

            return returnActors;
        }

        public async Task<ActorViewModel> GetActorByNameAsync(string name)
        {
            var actor = await this.context.Actors
        .Include(m => m.MovieActor)
            .ThenInclude(m => m.Movie)
        .FirstOrDefaultAsync(m => m.Name == name);

            if (actor == null)
            {
                throw new EntityInvalidException($"Actor with name `{name}` does not exist.");
            }

            var returnActor = this.mappingProvider.MapTo<ActorViewModel>(actor);

            return returnActor;
        }
    }
}