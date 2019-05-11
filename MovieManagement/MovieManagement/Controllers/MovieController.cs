using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Models.Movie;
using MovieManagement.Services.Contracts;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieManagement.ViewModels;
using System;

namespace MovieManagement.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;

        public MovieController(IMovieService movieService, IGenreService genreService)
        {
            this.movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
            this.genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
        }

        [HttpGet]
        public async Task<IActionResult> TopRated()
        {
            var model = new ListMovieViewModel();
            var movies = await this.movieService.GetTopRatedMoviesAsync();

            model.Movies = movies;
            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var model = await this.movieService.GetMovieByNameAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LatestMovies()
        {
            var model = new ListMovieViewModel();
            var movies = await this.movieService.GetLatestMoviesAsync();

            model.Movies = movies;
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Rate([FromBody] RateMovieViewModel rateMovieModel)
        {
            var movie = await this.movieService.RateMovieAsync(rateMovieModel.Name, rateMovieModel.Rating);

            return Json(movie);
        }

        [HttpGet]
        public async Task<IActionResult> Search(SearchMovieViewModel model)
        {
            if (string.IsNullOrEmpty(model.SearchName))
            {
                return View();
            }

            var movies = await this.movieService.SearchAsync(model.SearchName);

            model.Movies = movies;
            return View(model);
        }
    }
}