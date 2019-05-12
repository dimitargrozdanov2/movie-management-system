using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Controllers;
using MovieManagement.Models.Comment;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Controllers.CommentControllerTests
{
    [TestClass]
    public class AddComment_Should
    {
        [TestMethod]
        public async Task Call_CommentServiceWithCorrectParams_OnPost()
        {
            // Arrange
            string commentText = "Very interesting. Would love to see it!";

            string title = "Avengers EndGame";

            string userName = "BaiGrozdan";

            var commentServiceMock = new Mock<ICommentService>();

            var model = new CommentViewModel();


            commentServiceMock.Setup(asm => asm.AddComment(commentText,title,userName))
                    .ReturnsAsync(model);

            var createModel = new CreateCommentViewModel()
            {
                Text = commentText,
                Title = title,
                User = userName
            };

            var sut = new CommentController(commentServiceMock.Object);

            // Act
            var result = await sut.AddComment(createModel);

            // Assert
            commentServiceMock.Verify(x => x.AddComment(commentText, title, userName), Times.Once);
        }

        [TestMethod]
        public async Task RedirectToCorrectAction_OnPost()
        {
            // Arrange
            string commentText = "Very interesting. Would love to see it!";

            string title = "Avengers EndGame";

            string userName = "BaiGrozdan";

            var commentServiceMock = new Mock<ICommentService>();

            var model = new CommentViewModel();


            commentServiceMock.Setup(asm => asm.AddComment(commentText, title, userName))
                    .ReturnsAsync(model);

            var createModel = new CreateCommentViewModel()
            {
                Text = commentText,
                Title = title,
                User = userName
            };

            var sut = new CommentController(commentServiceMock.Object);

            // Act
            var result = await sut.AddComment(createModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirect = (RedirectToActionResult)result;

            Assert.IsTrue(redirect.ControllerName == "News");
            Assert.IsTrue(redirect.ActionName == "Details");
        }
    }
}
