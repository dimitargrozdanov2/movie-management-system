using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Areas.Administration.Models.Role;
using MovieManagement.Wrappers;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleManagerWrapper roleManagerWrapper;

        public RoleController(IRoleManagerWrapper roleManagerWrapper)
        {
            this.roleManagerWrapper = roleManagerWrapper;
        }

        public IActionResult Index()
        {
            var model = new RoleIndexViewModel();

            var roles = this.roleManagerWrapper.GetAllRoles().OrderBy(x => x.Name);

            model.Roles = roles;

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel model)
        {
            var role = await this.roleManagerWrapper.CreateRoleAsync(model.Name);

            return this.RedirectToAction(nameof(Index), "Role");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await this.roleManagerWrapper.FindByNameAsync(id);

            await this.roleManagerWrapper.DeleteRoleAsync(id);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var model = new RoleEditViewModel();
            model.OldName = id;
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleEditViewModel model)
        {
            var role = await this.roleManagerWrapper.FindByNameAsync(model.OldName);

            role.Name = model.NewName;

            await this.roleManagerWrapper.UpdateRoleAsync(role);

            return this.RedirectToAction(nameof(Index));
        }
    }
}