using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Areas.Administration.Controllers;
using MovieManagement.Services.Contracts;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Areas.Administration.ControllerTests.MovieManagementControllerTests
{
    [TestClass]
    public class Delete_Should
    {
        [TestMethod] // OK!
        public void ReturnCorrectViewModel_OnGet()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);

            // Act
            var result = sut.Delete() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod] // OK!
        public async Task Call_MovieServiceOnce_OnPost()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);

            string movieName = "Spiderman";

            // Act
            var result = await sut.Delete(movieName);

            // Assert
            movieServiceMock.Verify(x => x.DeleteMovieAsync(movieName));
        }

        [TestMethod] // OK!
        public async Task Redirect_ToCorrectAction_OnPost()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);

            string movieName = "Spiderman";

            // Act
            var result = await sut.Delete(movieName);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirect = (RedirectToActionResult)result;

            // They are redirecting to the basic Movie Controller, not the MovieManagement one.
            Assert.IsTrue(redirect.ControllerName == "Movie");
            Assert.IsTrue(redirect.ActionName == "TopRated");
        }

        [TestMethod] // OK!
        public async Task Redirect_ToViewResult_IfModelInvalid_OnPost()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            var sut = new MovieManagementController(movieServiceMock.Object, genreServiceMock.Object);
            sut.ModelState.AddModelError("error", "error");

            string movieName = "Spiderman";

            // Act
            var result = await sut.Delete(movieName);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}