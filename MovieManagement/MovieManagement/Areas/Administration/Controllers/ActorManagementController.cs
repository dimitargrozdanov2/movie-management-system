﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Areas.Administration.Models.Actor;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Threading.Tasks;

namespace MovieManagement.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class ActorManagementController : Controller
    {
        private readonly IActorService actorService;

        public ActorManagementController(IActorService actorService)
        {
            this.actorService = actorService ?? throw new ArgumentNullException(nameof(actorService));
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateActorViewModel();

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateActorViewModel model)
        {
            var role = await this.actorService.CreateActorAsync(model.Name);

            return this.RedirectToAction("Index", "Actor");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string oldName)
        {
            var model = await this.actorService.GetActorByNameAsync(oldName);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string oldName, ActorViewModel model)
        {
            await this.actorService.ChangeActorNameAsync(oldName, model);

            return this.RedirectToAction("Index", "Actor");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string actorName)
        {
            await this.actorService.DeleteActorAsync(actorName);

            return this.RedirectToAction("Index", "Actor");
        }
    }
}