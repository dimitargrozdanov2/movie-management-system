using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Areas.Administration.Controllers;
using MovieManagement.Areas.Administration.Models.News;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Areas.Administration.ControllerTests.NewsManagementControllerTests
{
    [TestClass]
    public class Create_Should
    {
        [TestMethod]
        public void ReturnCorrectViewModel_OnGet()
        {
            // Arrange
            var newsServiceMock = new Mock<INewsService>();

            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();

            var sut = new NewsManagementController(newsServiceMock.Object, hostingEnvironmentMock.Object);

            // Act
            var result = sut.Create() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(CreateNewsViewModel));
        }

        //[TestMethod]
        //public async Task RedirectToCorrectAction_OnPost()
        //{
        //    // Arrange
        //    DateTime createdOn = DateTime.Now;
        //    string title = "Tony Stark dies in Avengers!";
        //    string text = "Tony had to sacrifice himself for the greater good in the battle with Tanos";
        //    string imageNameToSave = Guid.NewGuid() + ".jpg";

        //    var ms = new MemoryStream();
        //    var formFile = new FormFile(ms, 0, ms.Length, "name", imageNameToSave);

        //    var newsServiceMock = new Mock<INewsService>();

        //    var hostingEnvironmentMock = new Mock<IHostingEnvironment>();

        //    var currentDirectory = Directory.GetCurrentDirectory();
        //    var endIndex = currentDirectory.IndexOf(@"\MovieManagement\");
        //    var wwwrootFolderPath = "\\MovieManagement\\MovieManagement\\wwwroot";
        //    var path = Path.Combine(currentDirectory.Substring(0, endIndex) + wwwrootFolderPath);

        //    hostingEnvironmentMock.SetupGet(x => x.WebRootPath).Returns(path);
        //    var model = new NewsViewModel()
        //    {
        //        CreatedOn = createdOn,
        //        Title = title,
        //        Text = text,
        //        Image = imageNameToSave
        //    };

        //    newsServiceMock.Setup(ns => ns.CreateNewsAsync(createdOn, title, text, imageNameToSave)).ReturnsAsync(model);

        //    var createModel = new CreateNewsViewModel()
        //    {
        //        CreatedOn = createdOn,
        //        Title = title,
        //        Text = text,
        //        Image = formFile
        //    };

        //    var sut = new NewsManagementController(newsServiceMock.Object, hostingEnvironmentMock.Object);

        //    // Act
        //    var result = await sut.Create(createModel);

        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        //    var redirect = (RedirectToActionResult)result;

        //    var uploadedFolder = Path.Combine(path, "images");
        //    var uploadedFilePath = Path.Combine(uploadedFolder, imageNameToSave);
        //    string details = redirect.ToString();

        //    // They are redirecting to the basic Movie Controller, not the MovieManagement one.
        //    Assert.IsTrue(redirect.ControllerName == "News");
        //    Assert.IsTrue(redirect.ActionName == "Index");
        //}
    }
}


