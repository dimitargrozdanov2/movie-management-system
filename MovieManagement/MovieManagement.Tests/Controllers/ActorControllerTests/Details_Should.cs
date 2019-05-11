using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Controllers;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Controllers.ActorControllerTests
{
    [TestClass]
    public class Details_Should
    {
        [TestMethod]
        public async Task CallActorServiceOnce_OnGet()
        {
            // Arrange
            var actorServiceMock = new Mock<IActorService>();

            string actorName = "Dolph Lundgren";

            var actorViewModel = new ActorViewModel();

            actorServiceMock
                .Setup(g => g.GetActorByNameAsync(actorName))
                .ReturnsAsync(actorViewModel);

            var sut = new ActorController(actorServiceMock.Object);

            // Act
            await sut.Details(actorName);

            // Assert
            actorServiceMock.Verify(g => g.GetActorByNameAsync(actorName), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel_OnGet()
        {
            // Arrange
            var actorServiceMock = new Mock<IActorService>();

            string actorName = "Dolph Lundgren";

            var actorViewModel = new ActorViewModel();

            actorServiceMock
                .Setup(g => g.GetActorByNameAsync(actorName))
                .ReturnsAsync(actorViewModel);

            var sut = new ActorController(actorServiceMock.Object);

            // Act
            var result = await sut.Details(actorName) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(ActorViewModel));
        }
    }
}
