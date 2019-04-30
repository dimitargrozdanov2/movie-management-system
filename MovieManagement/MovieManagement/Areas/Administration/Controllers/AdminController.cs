﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Areas.Administration.Models;
using MovieManagement.Areas.Administration.Models.User;
using MovieManagement.DataModels;
using MovieManagement.Services.Contracts;
using MovieManagement.Wrappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieManagement.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserManagerWrapper userManagerWrapper;
        private readonly IUserService userService;

        public AdminController(IUserManagerWrapper userManagerWrapper,
            IUserService userService)
        {
            this.userManagerWrapper = userManagerWrapper;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new IndexViewModel();

            var users = await this.userService.GetAllUsers();

            model.Users = users;

            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateRole(string id)
        {
            var model = new UpdateRoleViewModel();
            model.UserName = id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            var user = await this.userManagerWrapper.FindByNameAsync(model.UserName);

            if (user == null)
            {
                throw new ArgumentNullException("User not found!");
            }

            await this.userManagerWrapper.AddToRoleAsync(user, model.RoleName);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult EditUser(string id)
        {
            var model = new EditUserViewModel();
            model.OldName = id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await this.userManagerWrapper.FindByNameAsync(model.OldName);

            if (user == null)
            {
                throw new ArgumentNullException("User not found!");
            }

            user.UserName = model.NewName;

            var ss = await this.userManagerWrapper.UpdateUserAsync(user);

            //var role = this.roleManager.CreateAsync(new IdentityRole(model.RoleName));
            //role.Wait();

            //var a = this.userManager.GetRolesAsync(user.Result).Result;

            //var b = this.userManager.GetUsersInRoleAsync(model.RoleName).Result;

            //var c = this.userManager.IsInRoleAsync(user.Result, model.RoleName).Result;

            //var d = this.userManager.Users;


            return this.RedirectToAction(nameof(Index));
        }
    }
}