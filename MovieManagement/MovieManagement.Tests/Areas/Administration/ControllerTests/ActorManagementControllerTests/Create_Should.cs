﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Areas.Administration.Controllers;
using MovieManagement.Areas.Administration.Models.Actor;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        [TestMethod]
        public async Task Call_ActorServiceWithCorrectParams_OnPost()
        {
            // Arrange
            string actorName = "Brat Pitt";

            var actorServiceMock = new Mock<IActorService>();

            var model = new ActorViewModel()
            {
                Name = actorName,
            };

            actorServiceMock.Setup(asm => asm.CreateActorAsync(actorName))
                    .ReturnsAsync(model);

            var createModel = new CreateActorViewModel()
            {
                Name = actorName
            };

            var sut = new ActorManagementController(actorServiceMock.Object);

            // Act
            var result = await sut.Create(createModel);

            // Assert
            actorServiceMock.Verify(x => x.CreateActorAsync(actorName), Times.Once);
        }

        [TestMethod]
        public async Task RedirectToCorrectAction_OnPost()
        {
            // Arrange
            var actorServiceMock = new Mock<IActorService>();

            actorServiceMock.Setup(asm => asm.CreateActorAsync(null))
                    .ReturnsAsync(new ActorViewModel());

            var createModel = new CreateActorViewModel();

            var sut = new ActorManagementController(actorServiceMock.Object);

            // Act
            var result = await sut.Create(createModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirect = (RedirectToActionResult)result;

            Assert.IsTrue(redirect.ControllerName == "Actor");
            Assert.IsTrue(redirect.ActionName == "Index");
        }
    }
}
