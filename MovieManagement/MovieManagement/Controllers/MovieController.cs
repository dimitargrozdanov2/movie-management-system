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

        [Area("Administration")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateMovieViewModel();
            var genres = await this.genreService.GetAllGenres();
            model.GenreList = genres.Select(t => new SelectListItem(t.Name, t.Name)).ToList();

            return View(model);
        }

        [Area("Administration")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieViewModel model)
        {
            var role = await this.movieService.CreateMovieAsync(model.Name, model.Duration, model.Storyline, model.Director, model.GenreName);


            // TODO: RETURN DIRECTOYL TO THE DETAILS OF THIS ONE;
            return this.RedirectToAction(nameof(Index), "Role");
        }
    }
}