using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Areas.Administration.Controllers;
using MovieManagement.Areas.Administration.Models.Movie;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Areas.Administration.ControllerTests.MovieManagementControllerTests
{
    [TestClass]
    public class ManageActors_Should
    {
        [TestMethod]
        public void ReturnCorrectViewModel_OnGet()
        {
            // Arrange
            string movieName = "Spiderman";

            var genreServiceMock = new Mock<IGenreService>();
            var movieServiceMock = new Mock<IMovieService>();

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            var result = sut.ManageActors(movieName) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(MovieManageActorsViewModel));
        }

        [TestMethod]
        public async Task Call_MovieServiceWithCorrectParams_OnPost()
        {
            // Arrange
            string movieName = "Spiderman";
            string actorName = "John John";

            var genreServiceMock = new Mock<IGenreService>();
            var movieServiceMock = new Mock<IMovieService>();

            var movieManageActorsModel = new Mock<MovieManageActorsViewModel>();
            movieManageActorsModel.Object.MovieName = movieName;
            movieManageActorsModel.Object.ActorName = actorName;

            var movieViewModel = new MovieViewModel();

            movieServiceMock
                .Setup(g => g.ManageActorAsync(movieName, actorName))
                .ReturnsAsync(movieViewModel);

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            var result = await sut.ManageActors(movieManageActorsModel.Object);

            // Assert
            movieServiceMock.Verify(x => x.ManageActorAsync(movieName, actorName), Times.Once);
        }

        [TestMethod]
        public async Task RedirectToCorrectAction_OnPost()
        {
            // Arrange
            string movieName = "Spiderman";
            string actorName = "John John";

            var genreServiceMock = new Mock<IGenreService>();
            var movieServiceMock = new Mock<IMovieService>();

            var movieManageActorsModel = new Mock<MovieManageActorsViewModel>();
            movieManageActorsModel.Object.MovieName = movieName;
            movieManageActorsModel.Object.ActorName = actorName;

            var movieViewModel = new MovieViewModel();

            movieServiceMock
                .Setup(g => g.ManageActorAsync(movieName, actorName))
                .ReturnsAsync(movieViewModel);

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            var result = await sut.ManageActors(movieManageActorsModel.Object);

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
            string movieName = "Spiderman";
            string actorName = "John John";

            var genreServiceMock = new Mock<IGenreService>();
            var movieServiceMock = new Mock<IMovieService>();

            var movieManageActorsModel = new Mock<MovieManageActorsViewModel>();
            movieManageActorsModel.Object.MovieName = movieName;
            movieManageActorsModel.Object.ActorName = actorName;

            var movieViewModel = new MovieViewModel();

            movieServiceMock
                .Setup(g => g.ManageActorAsync(movieName, actorName))
                .ReturnsAsync(movieViewModel);

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);
            sut.ModelState.AddModelError("error", "error");

            // Act
            var result = await sut.ManageActors(movieManageActorsModel.Object);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResultRedirect = (ViewResult)result;
            Assert.IsInstanceOfType(viewResultRedirect.Model, typeof(MovieManageActorsViewModel));
        }
    }
}
