using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieManagement.Areas.Administration.Models.Movie;
using MovieManagement.Services.Contracts;

namespace MovieManagement.Areas.Administration.Controllers
{
    public class MovieManagementController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;

        public MovieManagementController(IMovieService movieService, IGenreService genreService)
        {
            this.movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
            this.genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
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
            return this.RedirectToAction("Index", "Home");
        }
    }
}