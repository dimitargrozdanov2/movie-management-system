using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Controllers;
using MovieManagement.Models.News;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Controllers.NewsControllerTests
{
    [TestClass]
    public class Index_Should
    {
        [TestMethod]
        public async Task CallNewsServiceOnce_OnGet()
        {
            // Arrange
            var newsServiceMock = new Mock<INewsService>();

            var newsList = new List<NewsViewModel>();

            newsServiceMock
                .Setup(g => g.GetAllNewsAsync())
                .ReturnsAsync(newsList);

            var sut = new NewsController(newsServiceMock.Object);

            // Act
            await sut.Index();

            // Assert
            newsServiceMock.Verify(g => g.GetAllNewsAsync(), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel_OnGet()
        {
            // Arrange
            var newsServiceMock = new Mock<INewsService>();

            var newsList = new List<NewsViewModel>();

            newsServiceMock
                .Setup(g => g.GetAllNewsAsync())
                .ReturnsAsync(newsList);

            var sut = new NewsController(newsServiceMock.Object);

            // Act
            var result = await sut.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(ListNewsViewModel));
        }
    }
}
