using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Areas.Administration.Models;
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
        private readonly IUserManagerWrapper managerWrapper;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public AdminController(IUserManagerWrapper managerWrapper,
            RoleManager<IdentityRole> roleManager,
            IUserService userService,
            IMapper mapper)
        {
            this.managerWrapper = managerWrapper;
            this.roleManager = roleManager;
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var model = new IndexViewModel();

            var users = await this.userService.GetAllUsers();

            var mappedUsers = this.mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<ApplicationUserViewModel>>(users);

            model.Users = mappedUsers;

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
            var user = await this.managerWrapper.FindByNameAsync(model.UserName);

            if (user == null)
            {
                throw new ArgumentNullException("User not found!");
            }

            //var role = this.roleManager.CreateAsync(new IdentityRole(model.RoleName));
            //role.Wait();

            //var a = this.userManager.GetRolesAsync(user.Result).Result;

            //var b = this.userManager.GetUsersInRoleAsync(model.RoleName).Result;

            //var c = this.userManager.IsInRoleAsync(user.Result, model.RoleName).Result;

            //var d = this.userManager.Users;

            // TODO ADD THIS TOO;
            //await this.managerWrapper.AddToRoleAsync(user, model.RoleName);

            return this.RedirectToAction(nameof(Index));
        }
    }
}