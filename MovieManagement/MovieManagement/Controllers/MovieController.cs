using Microsoft.AspNetCore.Mvc;
using MovieManagement.Models.Movie;
using MovieManagement.Services.Contracts;
using System.Threading.Tasks;

namespace MovieManagement.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
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
    }
}