using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Infrastructure;
using MovieManagement.Services;
using MovieManagement.Services.Exceptions;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Services.CommentServiceTests
{
    [TestClass]
    public class AddComment_Should
    {
        [TestMethod]
        public async Task Throw_WhenText_IsEmpty()
        {
            var dabataseName = nameof(Throw_WhenText_IsEmpty);

            var options = CommentTestUtil.GetOptions(dabataseName);

            var mappingProviderMock = new Mock<IMappingProvider>();

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new CommentService(actAndAssertContext, mappingProviderMock.Object);

                string commentText = null;

                string title = "Avengers EndGame";

                string userName = "BaiGrozdan";

                await Assert.ThrowsExceptionAsync<EntityInvalidException>(
                    async () => await sut.AddComment(commentText,title,userName));
            }
        }

        [TestMethod]
        public async Task AddNewComment_WhenAllParametersAreValid()
        {
            var dabataseName = nameof(Throw_WhenText_IsEmpty);

            var options = CommentTestUtil.GetOptions(dabataseName);

            var mappingProviderMock = new Mock<IMappingProvider>();

            string commentText = "Very interesting.Would love to see it!";

            string title = "Avengers EndGame";

            string userName = "BaiGrozdan";


            using (var arrangeContext = new MovieManagementContext(options))
            {
                var sut = new CommentService(arrangeContext, mappingProviderMock.Object);


                await sut.AddComment(commentText, title, userName);

                arrangeContext.SaveChanges();
            }

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                Assert.IsTrue(actAndAssertContext.Comments.Count() == 1);
                Assert.IsTrue(actAndAssertContext.Comments.Any(m => m.Text == commentText));
            }
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel()
        {
            var dabataseName = nameof(Throw_WhenText_IsEmpty);

            var options = CommentTestUtil.GetOptions(dabataseName);

            var mappingProviderMock = new Mock<IMappingProvider>();

            string commentText = "Very interesting.Would love to see it!";

            string title = "Avengers EndGame";

            string userName = "BaiGrozdan";

            mappingProviderMock.Setup(x => x.MapTo<CommentViewModel>(It.IsAny<Comment>())).Returns(new CommentViewModel());

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new CommentService(actAndAssertContext, mappingProviderMock.Object);

                var result = await sut.AddComment(commentText, title, userName);

                Assert.IsInstanceOfType(result, typeof(CommentViewModel));
            }
        }
    }
}
