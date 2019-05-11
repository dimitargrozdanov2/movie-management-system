using Microsoft.AspNetCore.Mvc;
using MovieManagement.Models.Actor;
using MovieManagement.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace MovieManagement.Controllers
{
    public class ActorController : Controller
    {
        private IActorService actorService;

        public ActorController(IActorService actorService)
        {
            this.actorService = actorService ?? throw new ArgumentNullException(nameof(actorService));
        }

        // GET: Actor
        public async Task<IActionResult> Index()
        {
            var model = new ListActorViewModel();
            var actors = await this.actorService.GetAllActorsAsync();

            model.Actors = actors;
            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var model = await this.actorService.GetActorByNameAsync(id);

            return this.View(model);
        }
    }
}