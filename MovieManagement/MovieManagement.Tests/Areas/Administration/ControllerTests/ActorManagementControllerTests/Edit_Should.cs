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

namespace MovieManagement.Tests.Areas.Administration.ControllerTests.ActorManagementControllerTests
{
    [TestClass]
    public class Edit_Should
    {
        [TestMethod]
        public async Task CallActorServiceOnce_OnGet()
        {
            // Arrange
            var actorServiceMock = new Mock<IActorService>();

            string actorName = "Dolph Lundgren";

            actorServiceMock
                .Setup(g => g.GetActorByNameAsync(actorName))
                .ReturnsAsync(new ActorViewModel());

            var sut = new ActorManagementController(actorServiceMock.Object);

            // Act
            var result = await sut.Edit(actorName);

            // Assert
            actorServiceMock.Verify(m => m.GetActorByNameAsync(actorName), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel_OnGet()
        {
            // Arrange
            string actorName = "Dolph Lundgren";

            var actorServiceMock = new Mock<IActorService>();

            var actorViewModel = new ActorViewModel();

            actorServiceMock
                .Setup(g => g.GetActorByNameAsync(actorName))
                .ReturnsAsync(actorViewModel);

            var sut = new ActorManagementController(actorServiceMock.Object);

            // Act
            var result = await sut.Edit(actorName) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(ActorViewModel));
        }

        [TestMethod]
        public async Task Call_ActorServiceWithCorrectParams_OnPost()
        {
            // Arrange
            string actorName = "Dolph Lundgren";

            var actorServiceMock = new Mock<IActorService>();

            var actorViewModel = new ActorViewModel();

            actorServiceMock
                .Setup(g => g.GetActorByNameAsync(actorName))
                .ReturnsAsync(actorViewModel);

            actorServiceMock
                .Setup(g => g.ChangeActorNameAsync(actorName, actorViewModel))
                .ReturnsAsync(actorViewModel);

            var sut = new ActorManagementController(actorServiceMock.Object);

            // Act
            var result = await sut.Edit(actorName, actorViewModel);

            // Assert
            actorServiceMock.Verify(x => x.ChangeActorNameAsync(actorName, actorViewModel), Times.Once);
        }

        [TestMethod]
        public async Task RedirectToCorrectAction_OnPost()
        {
            // Arrange
            string actorName = "Dolph Lundgren";

            var actorServiceMock = new Mock<IActorService>();

            var actorViewModel = new ActorViewModel();

            actorServiceMock
                .Setup(g => g.GetActorByNameAsync(actorName))
                .ReturnsAsync(actorViewModel);

            actorServiceMock
                .Setup(g => g.ChangeActorNameAsync(actorName, actorViewModel))
                .ReturnsAsync(actorViewModel);

            var sut = new ActorManagementController(actorServiceMock.Object);

            // Act
            var result = await sut.Edit(actorName, actorViewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirect = (RedirectToActionResult)result;

            Assert.IsTrue(redirect.ControllerName == "Actor");
            Assert.IsTrue(redirect.ActionName == "Index");
        }
    }
}
