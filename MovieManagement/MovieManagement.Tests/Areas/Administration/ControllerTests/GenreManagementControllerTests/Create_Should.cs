using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Areas.Administration.Controllers;
using MovieManagement.Areas.Administration.Models.Genre;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Areas.Administration.ControllerTests.GenreManagementControllerTests
{
    [TestClass]
    public class Create_Should
    {
        [TestMethod]
        public void ReturnCorrectViewModel_OnGet()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            var sut = new GenreManagementController(movieServiceMock.Object, genreServiceMock.Object);

            string genreName = "Comedy";

            // Act
            var result = sut.Create() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task Call_GenreServiceWithCorrectParams_OnPost()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            var sut = new GenreManagementController(movieServiceMock.Object, genreServiceMock.Object);

            string genreName = "Comedy";

            var createGenreModel = new CreateGenreViewModel()
            {
                Name = genreName
            };

            genreServiceMock.Setup(g => g.CreateGenreAsync(genreName))
                .ReturnsAsync(new GenreViewModel());

            // Act
            var result = await sut.Create(createGenreModel);

            // Assert
            genreServiceMock.Verify(g => g.CreateGenreAsync(genreName), Times.Once);
        }

        [TestMethod]
        public async Task RedirectToCorrectAction_OnPost()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            var sut = new GenreManagementController(movieServiceMock.Object, genreServiceMock.Object);

            string genreName = "Comedy";

            var createGenreModel = new CreateGenreViewModel()
            {
                Name = genreName
            };

            genreServiceMock.Setup(g => g.CreateGenreAsync(genreName))
                .ReturnsAsync(new GenreViewModel());

            // Act
            var result = await sut.Create(createGenreModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirect = (RedirectToActionResult)result;

            // They are redirecting to the basic Movie Controller, not the MovieManagement one.
            Assert.IsTrue(redirect.ControllerName == "Admin");
            Assert.IsTrue(redirect.ActionName == "Index");
        }

        [TestMethod]
        public async Task Redirect_ToViewResult_IfModelInvalid_OnPost()
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            var genreServiceMock = new Mock<IGenreService>();

            var sut = new GenreManagementController(movieServiceMock.Object, genreServiceMock.Object);
            sut.ModelState.AddModelError("error", "error");

            string genreName = "Comedy";

            var createGenreModel = new CreateGenreViewModel()
            {
                Name = genreName
            };

            genreServiceMock.Setup(g => g.CreateGenreAsync(genreName))
                .ReturnsAsync(new GenreViewModel());

            // Act
            var result = await sut.Create(createGenreModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResultRedirect = (ViewResult)result;

            Assert.IsInstanceOfType(viewResultRedirect.Model, typeof(CreateGenreViewModel));
        }
    }
}