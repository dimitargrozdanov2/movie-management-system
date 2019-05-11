using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Controllers;
using MovieManagement.DataModels;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Controllers.MovieControllerTests
{
    [TestClass]
    public class Details_Should
    {
        [TestMethod]
        public async Task CallMovieServiceOnce_OnGet()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            string movieName = "Spiderman";

            movieServiceMock
                .Setup(g => g.GetMovieByNameAsync(movieName))
                .ReturnsAsync(new MovieViewModel());

            var sut = new MovieController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            await sut.Details(movieName);

            // Assert
            movieServiceMock.Verify(g => g.GetMovieByNameAsync(movieName), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel_OnGet()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            string movieName = "Spiderman";

            movieServiceMock
                .Setup(g => g.GetMovieByNameAsync(movieName))
                .ReturnsAsync(new MovieViewModel());

            var sut = new MovieController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            var result = await sut.Details(movieName) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(MovieViewModel));
        }
    }
}
