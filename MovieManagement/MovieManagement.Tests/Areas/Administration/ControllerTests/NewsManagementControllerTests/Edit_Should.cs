using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Areas.Administration.Controllers;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Areas.Administration.ControllerTests.NewsManagementControllerTests
{
    [TestClass]
    public class Edit_Should
    {
        [TestMethod]
        public async Task CallNewsServiceOnce_OnGet()
        {
            // Arrange
            var newsServiceMock = new Mock<INewsService>();

            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();

            var newsViewModel = new NewsViewModel();

            var newsTitle = "More marvel movies will be producted";
            newsServiceMock
                .Setup(g => g.GetNewsByNameAsync(newsTitle))
                .ReturnsAsync(newsViewModel);

            var sut = new NewsManagementController(newsServiceMock.Object, hostingEnvironmentMock.Object);

            // Act
            var result = await sut.Edit(newsTitle);

            // Assert
            newsServiceMock.Verify(m => m.GetNewsByNameAsync(newsTitle), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel_OnGet()
        {
            //Arrange
            var newsServiceMock = new Mock<INewsService>();

            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();

            var newsViewModel = new NewsViewModel();

            var newsTitle = "More marvel movies will be producted";

            newsServiceMock
                .Setup(g => g.GetNewsByNameAsync(newsTitle))
                .ReturnsAsync(newsViewModel);

            var sut = new NewsManagementController(newsServiceMock.Object, hostingEnvironmentMock.Object);

            // Act
            var result = await sut.Edit(newsTitle) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(NewsViewModel));
        }

        [TestMethod]
        public async Task Call_NewsServiceWithCorrectParams_OnPost()
        {
            // Arrange
            var newsServiceMock = new Mock<INewsService>();

            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();

            var newsViewModel = new NewsViewModel();

            var newsTitle = "More marvel movies will be producted";

            newsServiceMock
               .Setup(g => g.GetNewsByNameAsync(newsTitle))
               .ReturnsAsync(newsViewModel);

            newsServiceMock
                .Setup(g => g.EditNewsTextAsync(newsTitle, newsViewModel))
                .ReturnsAsync(newsViewModel);

            var sut = new NewsManagementController(newsServiceMock.Object, hostingEnvironmentMock.Object);

            // Act
            var result = await sut.Edit(newsTitle, newsViewModel);

            // Assert
            newsServiceMock.Verify(x => x.EditNewsTextAsync(newsTitle, newsViewModel), Times.Once);
        }

        [TestMethod]
        public async Task RedirectToCorrectAction_OnPost()
        {
            // Arrange
            var newsServiceMock = new Mock<INewsService>();

            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();

            var newsViewModel = new NewsViewModel();

            var newsTitle = "More marvel movies will be producted";

            newsServiceMock
               .Setup(g => g.GetNewsByNameAsync(newsTitle))
               .ReturnsAsync(newsViewModel);

            newsServiceMock
                .Setup(g => g.EditNewsTextAsync(newsTitle, newsViewModel))
                .ReturnsAsync(newsViewModel);

            var sut = new NewsManagementController(newsServiceMock.Object, hostingEnvironmentMock.Object);

            // Act
            var result = await sut.Edit(newsTitle, newsViewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirect = (RedirectToActionResult)result;

            Assert.IsTrue(redirect.ControllerName == "News");
            Assert.IsTrue(redirect.ActionName == "Index");
        }
    }
}
