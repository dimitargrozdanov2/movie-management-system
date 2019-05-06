using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Models.Actor;
using MovieManagement.Services.Contracts;

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

            return View(model);
        }

    }
}
