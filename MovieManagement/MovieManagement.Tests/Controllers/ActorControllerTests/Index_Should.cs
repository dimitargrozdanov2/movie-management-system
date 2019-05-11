using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Controllers;
using MovieManagement.Models.Actor;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Controllers.ActorControllerTests
{
    [TestClass]
    public class Index_Should
    {
        [TestMethod]
        public async Task CallActorServiceOnce_OnGet()
        {
            // Arrange
            var actorServiceMock = new Mock<IActorService>();

            var actorsList = new List<ActorViewModel>();

            actorServiceMock
                .Setup(g => g.GetAllActorsAsync())
                .ReturnsAsync(actorsList);

            var sut = new ActorController(actorServiceMock.Object);

            // Act
            await sut.Index();

            // Assert
            actorServiceMock.Verify(g => g.GetAllActorsAsync(), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel_OnGet()
        {
            // Arrange
            var actorServiceMock = new Mock<IActorService>();

            var actorsList = new List<ActorViewModel>();

            actorServiceMock
                .Setup(g => g.GetAllActorsAsync())
                .ReturnsAsync(actorsList);

            var sut = new ActorController(actorServiceMock.Object);

            // Act
            var result = await sut.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(ListActorViewModel));
        }
    }
}
