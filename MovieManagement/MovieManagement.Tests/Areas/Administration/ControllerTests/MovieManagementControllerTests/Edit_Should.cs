using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Areas.Administration.Controllers;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Areas.Administration.ControllerTests.MovieManagementControllerTests
{
    [TestClass]
    public class Edit_Should
    {
        [TestMethod]
        public async Task CallMovieServiceOnce_OnGet()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();

            string movieName = "Spiderman";

            var genreServiceMock = new Mock<IGenreService>();
            movieServiceMock
                .Setup(g => g.GetMovieByNameAsync(movieName))
                .ReturnsAsync(new MovieViewModel());

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            var result = await sut.Edit(movieName);

            // Assert
            movieServiceMock.Verify(m => m.GetMovieByNameAsync(movieName), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel_OnGet()
        {
            // Arrange
            string movieName = "Spiderman";

            var genreServiceMock = new Mock<IGenreService>();
            var movieServiceMock = new Mock<IMovieService>();
            movieServiceMock
                .Setup(g => g.GetMovieByNameAsync(movieName))
                .ReturnsAsync(new MovieViewModel());

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            var result = await sut.Edit(movieName) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(MovieViewModel));
        }

        [TestMethod]
        public async Task Call_MovieServiceWithCorrectParams_OnPost()
        {
            // Arrange
            string movieName = "Spiderman";

            var genreServiceMock = new Mock<IGenreService>();
            var movieServiceMock = new Mock<IMovieService>();

            var movieViewModel = new MovieViewModel();

            movieServiceMock
                .Setup(g => g.GetMovieByNameAsync(movieName))
                .ReturnsAsync(movieViewModel);

            movieServiceMock
                .Setup(g => g.UpdateMovieAsync(movieName, movieViewModel))
                .ReturnsAsync(movieViewModel);

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            var result = await sut.Edit(movieName, movieViewModel);

            // Assert
            movieServiceMock.Verify(x => x.UpdateMovieAsync(movieName, movieViewModel), Times.Once);
        }

        [TestMethod]
        public async Task RedirectToCorrectAction_OnPost()
        {
            // Arrange
            string movieName = "Spiderman";

            var genreServiceMock = new Mock<IGenreService>();
            var movieServiceMock = new Mock<IMovieService>();

            var movieViewModel = new MovieViewModel();

            movieServiceMock
                .Setup(g => g.GetMovieByNameAsync(movieName))
                .ReturnsAsync(movieViewModel);

            movieServiceMock
                .Setup(g => g.UpdateMovieAsync(movieName, movieViewModel))
                .ReturnsAsync(movieViewModel);

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            var result = await sut.Edit(movieName, movieViewModel);

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

            var genreServiceMock = new Mock<IGenreService>();
            var movieServiceMock = new Mock<IMovieService>();

            var movieViewModel = new MovieViewModel();

            movieServiceMock
                .Setup(g => g.GetMovieByNameAsync(movieName))
                .ReturnsAsync(movieViewModel);

            movieServiceMock
                .Setup(g => g.UpdateMovieAsync(movieName, movieViewModel))
                .ReturnsAsync(movieViewModel);

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);
            sut.ModelState.AddModelError("error", "error");

            // Act
            var result = await sut.Edit(movieName, movieViewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResultRedirect = (ViewResult)result;
            Assert.IsInstanceOfType(viewResultRedirect.Model, typeof(MovieViewModel));
        }
    }
}