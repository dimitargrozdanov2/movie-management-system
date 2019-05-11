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
    public class Search_Should
    {
        [TestMethod]
        public async Task CallMovieServiceOnce_OnGet()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            string searchTerm = "hello";

            movieServiceMock
                .Setup(g => g.SearchAsync(searchTerm))
                .ReturnsAsync(new List<MovieViewModel>());

            var sut = new MovieController(movieServiceMock.Object, genreServiceMock.Object);

            var searchModel = new SearchMovieViewModel()
            {
                SearchName = searchTerm
            };

            // Act
            await sut.Search(searchModel);

            // Assert
            movieServiceMock.Verify(g => g.SearchAsync(searchTerm), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel_OnGet()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            string searchTerm = "hello";

            movieServiceMock
                .Setup(g => g.SearchAsync(searchTerm))
                .ReturnsAsync(new List<MovieViewModel>());

            var sut = new MovieController(movieServiceMock.Object, genreServiceMock.Object);

            var searchModel = new SearchMovieViewModel()
            {
                SearchName = searchTerm
            };

            // Act
            var result = await sut.Search(searchModel) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(SearchMovieViewModel));
        }

        [TestMethod]
        public async Task Redirect_ToViewResult_IfModelInvalid_OnPost()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            string searchTerm = "hello";

            movieServiceMock
                .Setup(g => g.SearchAsync(searchTerm))
                .ReturnsAsync(new List<MovieViewModel>());

            var sut = new MovieController(movieServiceMock.Object, genreServiceMock.Object);

            var searchModel = new SearchMovieViewModel();

            // Act
            var result = await sut.Search(searchModel) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
