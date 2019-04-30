using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Areas.Administration.Models.Role;
using MovieManagement.DataModels;
using MovieManagement.Services.Contracts;

namespace MovieManagement.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public RoleController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IUserService userService,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.userService = userService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = new RoleIndexViewModel();

            var roles = this.roleManager.Roles.OrderBy(x => x.Name).ToList();

            model.Roles = roles;

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateRoleViewModel model)
        {
            var role = this.roleManager.CreateAsync(new IdentityRole(model.Name)).Result;

            return this.RedirectToAction(nameof(Index), "Role");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();   
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = this.roleManager.FindByNameAsync(id).Result;

            if (role == null)
            {
                throw new ArgumentNullException("Role not found!");
            }

            //var roles = this.roleManager.Roles.ToList();

            await this.roleManager.DeleteAsync(role);

            //var roles2 = this.roleManager.Roles.ToList();

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var model = new EditViewModel();
            model.OldName = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            var role = this.roleManager.FindByNameAsync(model.OldName).Result;

            if (role == null)
            {
                throw new ArgumentNullException("Role not found!");
            }

            role.Name = model.NewName;

            await this.roleManager.UpdateAsync(role);

            //await this.roleManager.SetRoleNameAsync(role, model.NewName);

            return this.RedirectToAction(nameof(Index));
        }
    }
}