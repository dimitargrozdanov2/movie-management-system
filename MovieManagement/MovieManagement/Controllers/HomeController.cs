using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MovieManagement.Models;
using MovieManagement.Models.Home;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MovieManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IMemoryCache cacheService;

        public HomeController(IMovieService movieService, IMemoryCache cache)
        {
            this.movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
            this.cacheService = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeIndexViewModel();


            var cachedMovies = await this.cacheService.GetOrCreateAsync("Movies", async entry =>
            {
                entry.AbsoluteExpiration = DateTime.UtcNow.AddSeconds(20);
                var movies = await this.movieService.GetTopRatedMovies();
                return movies;
            });

            model.Movies = cachedMovies;

            return this.View(model);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
