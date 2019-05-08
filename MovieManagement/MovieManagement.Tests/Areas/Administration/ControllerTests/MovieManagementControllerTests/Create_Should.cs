using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Areas.Administration.Controllers;
using MovieManagement.Areas.Administration.Models.Movie;
using MovieManagement.DataModels;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace MovieManagement.Tests.Areas.Administration.ControllerTests.MovieManagementControllerTests
{
    [TestClass]
    public class Create_Should
    {
        [TestMethod] 
        public async Task CallGenreServiceOnce_OnGet()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();
            genreServiceMock
                .Setup(g => g.GetAllGenres())
                .ReturnsAsync(new List<Genre>());

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            await sut.Create();

            // Assert
            genreServiceMock.Verify(g => g.GetAllGenres(), Times.Once);
        }

        [TestMethod] 
        public async Task ReturnCorrectViewModel_OnGet()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();
            genreServiceMock
                .Setup(g => g.GetAllGenres())
                .ReturnsAsync(new List<Genre>());

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            var result = await sut.Create() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(MovieCreateViewModel));
        }


        [TestMethod]
        public async Task Call_MovieServiceWithCorrectParams_OnPost()
        {
            // Arrange
            string movieName = "Titanic";
            int duration = 90;
            string director = "TestDirector";
            string storyline = "TestStoryline";
            string imageUrl = "TestImageUrl";
            string genreName = "TestGenre";

            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            var model = new MovieViewModel()
            {
                Name = movieName,
                Duration = duration,
                Director = director,
                Storyline = storyline,
                ImageUrl = imageUrl,
                Genre = genreName
            };

            movieServiceMock.Setup(msm => msm.CreateMovieAsync(movieName, duration,
                    storyline, director, imageUrl, genreName))
                    .ReturnsAsync(model);


            var createModel = new MovieCreateViewModel()
            {
                Name = movieName,
                Duration = duration,
                Director = director,
                Storyline = storyline,
                ImageUrl = imageUrl,
                GenreName = genreName
            };

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            var result = await sut.Create(createModel);

            // Assert
            movieServiceMock.Verify(x => x.CreateMovieAsync(movieName, duration,
                    storyline, director, imageUrl, genreName), Times.Once);

        }

        [TestMethod]
        public async Task RedirectToCorrectAction_OnPost()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            movieServiceMock.Setup(msm => msm.CreateMovieAsync(null, 0,
                    null, null, null, null))
                    .ReturnsAsync(new MovieViewModel());

            var createModel = new MovieCreateViewModel();

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            var result = await sut.Create(createModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirect = (RedirectToActionResult)result;

            // They are redirecting to the basic Movie Controller, not the MovieManagement one.
            Assert.IsTrue(redirect.ControllerName == "Movie");
            Assert.IsTrue(redirect.ActionName == "Details");
        }

        [TestMethod]
        public async Task Redirect_ToViewResult_IfModelInvalid_OnPost()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            var createModel = new MovieCreateViewModel();

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);
            sut.ModelState.AddModelError("error", "error");

            // Act
            var result = await sut.Create(createModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResultRedirect = (ViewResult)result;

            Assert.IsInstanceOfType(viewResultRedirect.Model, typeof(MovieCreateViewModel));
        }
    }
}
