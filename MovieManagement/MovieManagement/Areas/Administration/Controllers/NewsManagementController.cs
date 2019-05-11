using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Areas.Administration.Models.News;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MovieManagement.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class NewsManagementController : Controller
    {
        private readonly INewsService newsService;

        private readonly IHostingEnvironment hostingEnvironment;

        public NewsManagementController(INewsService newsService, IHostingEnvironment hostingEnvironment)
        {
            this.newsService = newsService ?? throw new ArgumentNullException(nameof(newsService));
            this.hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateNewsViewModel();
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNewsViewModel model)
        {
            var imageNameToSave = Guid.NewGuid() + ".jpg";

            var role = await this.newsService.CreateNewsAsync(model.CreatedOn, model.Title, model.Text, imageNameToSave);

            using (var ms = new MemoryStream())
            {
                model.Image.CopyTo(ms);
                var uploads = Path.Combine(this.hostingEnvironment.WebRootPath, "images");
                var filePath = Path.Combine(uploads, imageNameToSave);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fileStream);
                }
            }

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string oldName)
        {
            var model = await this.newsService.GetNewsByNameAsync(oldName);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string oldName, NewsViewModel model)
        {
            await this.newsService.EditNewsTextAsync(oldName, model);

            return this.RedirectToAction("Index", "News");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            await this.newsService.DeleteNews(id);

            return this.RedirectToAction("Index", "News");
        }
    }
}