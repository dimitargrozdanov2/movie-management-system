using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Areas.Administration.Controllers;
using MovieManagement.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Areas.Administration.ControllerTests.ActorManagementControllerTests
{
    [TestClass]
    public class Delete_Should
    {
        [TestMethod]
        public void ReturnCorrectViewModel_OnGet()
        {
            //Arrange
            var actorServiceMock = new Mock<IActorService>();

            var sut = new ActorManagementController(actorServiceMock.Object);

            // Act
            var result = sut.Delete() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task Call_ActorServiceOnce_OnPost()
        {
            //Arrange
            var actorServiceMock = new Mock<IActorService>();

            var sut = new ActorManagementController(actorServiceMock.Object);

            string actorName = "Dolph Lundgren";

            // Act
            var result = await sut.Delete(actorName);

            // Assert
            actorServiceMock.Verify(x => x.DeleteActorAsync(actorName));
        }

        [TestMethod]
        public async Task Redirect_ToCorrectAction_OnPost()
        {
            //Arrange
            var actorServiceMock = new Mock<IActorService>();

            var sut = new ActorManagementController(actorServiceMock.Object);

            string actorName = "Dolph Lundgren";

            // Act
            var result = await sut.Delete(actorName);

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirect = (RedirectToActionResult)result;

            Assert.IsTrue(redirect.ControllerName == "Actor");
            Assert.IsTrue(redirect.ActionName == "Index");
        }
    }
}
