using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Areas.Administration.Models.Genre;
using MovieManagement.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace MovieManagement.Areas.Administration.Controllers
{
    public class GenreManagementController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;

        public GenreManagementController(IMovieService movieService, IGenreService genreService)
        {
            this.movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
            this.genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
        }

        [Area("Administration")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [Area("Administration")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateGenreViewModel model)
        {
            var role = await this.genreService.CreateGenreAsync(model.Name);

            // TODO: RETURN DIRECTOYL TO THE DETAILS OF THIS ONE;
            return this.RedirectToAction("Index", "Home");
        }
    }
}