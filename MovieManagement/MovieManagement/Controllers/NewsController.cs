using Microsoft.AspNetCore.Mvc;
using MovieManagement.Models.News;
using MovieManagement.Services.Contracts;
using System;
using System.Threading.Tasks;

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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new ListNewsViewModel();
            var news = await this.newsService.GetAllNewsAsync();

            model.News = news;
            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string title)
        {
            var model = await this.newsService.GetNewsByNameAsync(title);

            return this.View(model);
        }
    }
}