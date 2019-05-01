using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Models.Movie;
using MovieManagement.Services.Contracts;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MovieManagement.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;

        public MovieController(IMovieService movieService, IGenreService genreService)
        {
            this.movieService = movieService ?? throw new System.ArgumentNullException(nameof(movieService));
            this.genreService = genreService ?? throw new System.ArgumentNullException(nameof(genreService));
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> TopRated()
        {

            var getmovieswithActors = await this.movieService.GetMovieByNameAsync("Marvel");
            var model = new ListMovieViewModel();
            var movies = await this.movieService.GetTopRatedMovies();

            model.Movies = movies;
            return this.View(model);
        }
    }
}