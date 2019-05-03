using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Models.Movie;
using MovieManagement.Services.Contracts;

namespace MovieManagement.Controllers
{
    public class WatchlistController : Controller
    {
        private readonly IWatchlistService watchlistService;

        public WatchlistController(IWatchlistService watchlistService)
        {
            this.watchlistService = watchlistService ?? throw new ArgumentNullException(nameof(watchlistService));
        }

        public async Task<IActionResult> Index(string username)
        {
            var model = new ListMovieViewModel();
            var movies = await this.watchlistService.GetAllMovies(username);

            model.Movies = movies;
            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add(string username, string movieName)
        {
            await this.watchlistService.Add(username, movieName);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Remove(string username, string movieName)
        {
            await this.watchlistService.Remove(username, movieName);

            return View();
        }
    }
}