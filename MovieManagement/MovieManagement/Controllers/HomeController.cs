using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Models;
using MovieManagement.Models.Home;
using MovieManagement.Services.Contracts;

namespace MovieManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService movieService;

        public HomeController(IMovieService movieService)
        {
            this.movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeIndexViewModel();
            var movies = await this.movieService.GetTopRatedMovies();

            model.Movies = movies;
            return this.View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
