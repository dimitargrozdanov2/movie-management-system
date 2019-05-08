using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Controllers;
using MovieManagement.DataModels;
using MovieManagement.Models.Movie;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Controllers.MovieControllerTests
{
    [TestClass]
    public class Rate_Should
    {
        [TestMethod]
        public async Task CallMovieServiceOnce_OnGet()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            string movieName = "Spiderman";
            int rating = 10;

            var rateModel = new RateMovieViewModel()
            {
                Name = movieName,
                Rating = rating
            };

            movieServiceMock
                .Setup(g => g.RateMovieAsync(movieName, rating))
                .ReturnsAsync(new MovieViewModel());

            var sut = new MovieController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            await sut.Rate(rateModel);

            // Assert
            movieServiceMock.Verify(m => m.RateMovieAsync(movieName, rating), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel_OnGet()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            string movieName = "Spiderman";
            int rating = 10;

            var rateModel = new RateMovieViewModel()
            {
                Name = movieName,
                Rating = rating
            };

            movieServiceMock
                .Setup(g => g.RateMovieAsync(movieName, rating))
                .ReturnsAsync(new MovieViewModel());

            var sut = new MovieController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            var result = await sut.Rate(rateModel) as JsonResult;

            // Assert
            Assert.IsInstanceOfType(result.Value, typeof(MovieViewModel));
        }
    }
}
