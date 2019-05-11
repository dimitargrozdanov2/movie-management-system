using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieManagement.Areas.Administration.Models.Movie;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class MovieManagementController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;

        public MovieManagementController(IMovieService movieService, IGenreService genreService)
        {
            this.movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
            this.genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new MovieCreateViewModel();
            var genres = await this.genreService.GetAllGenres();
            model.GenreList = genres.Select(t => new SelectListItem(t.Name, t.Name)).ToList();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var movie = await this.movieService.CreateMovieAsync(model.Name, model.Duration, model.Storyline, model.Director, model.ImageUrl, model.GenreName);
                return this.RedirectToAction("Details", "Movie", new { id = movie.Name });
            }

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (this.ModelState.IsValid)
            {
                await this.movieService.DeleteMovieAsync(id);

                return this.RedirectToAction("TopRated", "Movie");
            }

            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string oldName)
        {
            if (this.ModelState.IsValid)
            {
                var model = await this.movieService.GetMovieByNameAsync(oldName);
                return this.View(model);
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string oldName, MovieViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var movie = await this.movieService.UpdateMovieAsync(oldName, model);

                return this.RedirectToAction("Details", "Movie", new { id = movie.Name });
            }

            return this.View(model);
        }

        [HttpGet]
        public IActionResult ManageActors(string name)
        {
            if (this.ModelState.IsValid)
            {
                var model = new MovieManageActorsViewModel();
                model.MovieName = name;

                return this.View(model);
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> ManageActors(MovieManageActorsViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var movie = await this.movieService.ManageActorAsync(model.MovieName, model.ActorName);

                return this.RedirectToAction("Details", "Movie", new { id = movie.Name });
            }

            return this.View(model);
        }
    }
}