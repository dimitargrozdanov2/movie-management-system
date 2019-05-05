using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Areas.Administration.Models.News;
using MovieManagement.Models.News;
using MovieManagement.Services.Contracts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieManagement.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService newsService;


        public NewsController(INewsService newsService)
        {
            this.newsService = newsService ?? throw new ArgumentNullException(nameof(newsService));
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var model = new ListNewsViewModel();
            var news = await this.newsService.GetAllNewsAsync();

            model.News = news;
            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var model = await this.newsService.GetNewsByNameAsync(id);

            return View(model);
        }
    }
}
