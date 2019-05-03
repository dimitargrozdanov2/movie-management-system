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

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> TopRated()
        {
            var model = new ListMovieViewModel();
            var movies = await this.movieService.GetTopRatedMovies();

            model.Movies = movies;
            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var model = await this.movieService.GetMovieByNameAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Rate([FromBody] RateMovieViewModel rateMovieModel)
        {
            var movie = await this.movieService.RateMovie(rateMovieModel.Name, rateMovieModel.Rating);

            return Json(movie);
        }
    }
}