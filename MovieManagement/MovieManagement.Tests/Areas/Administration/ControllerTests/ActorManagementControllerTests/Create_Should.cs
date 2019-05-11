using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Areas.Administration.Controllers;
using MovieManagement.Areas.Administration.Models.Actor;
using MovieManagement.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Tests.Areas.Administration.ControllerTests.ActorManagementControllerTests
{
    [TestClass]
    public class Create_Should
    {
        [TestMethod]
        public void ReturnCorrectViewModel_OnGet()
        {
            // Arrange
            var actorServiceMock = new Mock<IActorService>();

            var sut = new ActorManagementController(actorServiceMock.Object);

            // Act
            var result = sut.Create() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(CreateActorViewModel));
        }
    }
}
