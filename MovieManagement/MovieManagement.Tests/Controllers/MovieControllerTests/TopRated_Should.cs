﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Controllers;
using MovieManagement.Models.Movie;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Controllers.MovieControllerTests
{
    [TestClass]
    public class TopRated_Should
    {
        [TestMethod]
        public async Task CallMovieServiceOnce_OnGet()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();
            movieServiceMock
                .Setup(g => g.GetTopRatedMoviesAsync())
                .ReturnsAsync(new List<MovieViewModel>());

            var sut = new MovieController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            await sut.TopRated();

            // Assert
            movieServiceMock.Verify(g => g.GetTopRatedMoviesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel_OnGet()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();
            movieServiceMock
                .Setup(g => g.GetTopRatedMoviesAsync())
                .ReturnsAsync(new List<MovieViewModel>());

            var sut = new MovieController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            var result = await sut.TopRated() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(ListMovieViewModel));
        }
    }
}