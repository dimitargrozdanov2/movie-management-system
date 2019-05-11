﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MovieManagement.Models.Movie;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieManagement.Controllers
{
    public class WatchlistController : Controller
    {
        private readonly IWatchlistService watchlistService;
        private readonly IMemoryCache cacheService;
        private ICollection<MovieViewModel> cachedMovies;

        public WatchlistController(IWatchlistService watchlistService, IMemoryCache cacheService)
        {
            this.watchlistService = watchlistService ?? throw new ArgumentNullException(nameof(watchlistService));
            this.cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
        }

        public async Task<IActionResult> Index(string username)
        {
            var model = new ListMovieViewModel();

            this.cachedMovies = await this.cacheService.GetOrCreateAsync("Movies", async entry =>
            {
                entry.AbsoluteExpiration = DateTime.UtcNow.AddSeconds(10);
                var movies = await this.watchlistService.GetAllMovies(username);
                return movies;
            });

            model.Movies = this.cachedMovies;

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add(string username, string movieName)
        {
            await this.watchlistService.Add(username, movieName);
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Remove(string username, string movieName)
        {
            await this.watchlistService.Remove(username, movieName);
            return this.View();
        }
    }
}