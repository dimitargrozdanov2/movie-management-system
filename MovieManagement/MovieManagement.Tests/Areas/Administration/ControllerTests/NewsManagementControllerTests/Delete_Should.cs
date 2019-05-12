using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Areas.Administration.Controllers;
using MovieManagement.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Areas.Administration.ControllerTests.NewsManagementControllerTests
{
    [TestClass]
    public class Delete_Should
    {
        [TestMethod]
        public void ReturnCorrectViewModel_OnGet()
        {
            //Arrange
            var newsServiceMock = new Mock<INewsService>();

            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();

            var sut = new NewsManagementController(newsServiceMock.Object, hostingEnvironmentMock.Object);

            // Act
            var result = sut.Delete() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task Call_NewsServiceOnce_OnPost()
        {
            //Arrange
            var newsServiceMock = new Mock<INewsService>();

            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();

            var sut = new NewsManagementController(newsServiceMock.Object, hostingEnvironmentMock.Object);

            var newsTitle = "More marvel movies will be producted";

            // Act
            var result = await sut.Delete(newsTitle);

            // Assert
            newsServiceMock.Verify(x => x.DeleteNews(newsTitle));
        }

        [TestMethod]
        public async Task Redirect_ToCorrectAction_OnPost()
        {
            //Arrange
            var newsServiceMock = new Mock<INewsService>();

            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();

            var sut = new NewsManagementController(newsServiceMock.Object, hostingEnvironmentMock.Object);

            var newsTitle = "More marvel movies will be producted";

            // Act
            var result = await sut.Delete(newsTitle);

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirect = (RedirectToActionResult)result;

            Assert.IsTrue(redirect.ControllerName == "News");
            Assert.IsTrue(redirect.ActionName == "Index");
        }
    }
}
