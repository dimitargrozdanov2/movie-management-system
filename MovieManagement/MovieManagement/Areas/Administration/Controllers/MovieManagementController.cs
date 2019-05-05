using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using MovieManagement.Areas.Administration.Models.Movie;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;

namespace MovieManagement.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class MovieManagementController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;
        private readonly IMemoryCache cacheService;


        public MovieManagementController(IMovieService movieService, IGenreService genreService, IMemoryCache cacheService)
        {
            this.movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
            this.genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
            this.cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new MovieCreateViewModel();
            var genres = await this.genreService.GetAllGenres();
            model.GenreList = genres.Select(t => new SelectListItem(t.Name, t.Name)).ToList();

            return View(model);
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


            //UpdateCachedMovies();

        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var movie = await this.movieService.GetMovieByNameAsync(id);

            await this.movieService.DeleteMovieAsync(id);

            //UpdateCachedMovies();

            return this.RedirectToAction("TopRated", "Movie");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string oldName)
        {
            var model = await this.movieService.GetMovieByNameAsync(oldName);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string oldName, MovieViewModel model)
        {
            await this.movieService.UpdateMovieAsync(oldName, model);

            return this.RedirectToAction("TopRated", "Movie");
        }

        [HttpGet]
        public IActionResult ManageActors(string name)
        {
            var model = new MovieManageActorsViewModel();
            model.MovieName = name;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageActors(MovieManageActorsViewModel model)
        {
            await this.movieService.ManageActorAsync(model.MovieName, model.ActorName);

            return this.RedirectToAction("TopRated", "Movie");
        }

        //private async void UpdateCachedMovies()
        //{
        //    this.cacheService.Remove("Movies");
        //    //this.cacheService.Set("Movies", this.movieService.GetTopRatedMovies(), DateTime.UtcNow.AddMinutes(30));

        //    var cachedMovies = await this.cacheService.GetOrCreateAsync("Movies", async entry =>
        //    {
        //        entry.AbsoluteExpiration = DateTime.UtcNow.AddSeconds(10);
        //        var movies = await this.movieService.GetTopRatedMovies();
        //        return movies;
        //    });

        //}
    }
}