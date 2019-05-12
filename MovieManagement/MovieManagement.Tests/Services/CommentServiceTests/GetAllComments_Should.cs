using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Infrastructure;
using MovieManagement.Services;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Services.CommentServiceTests
{
    [TestClass]
    public class GetAllComments_Should
    {
        [TestMethod]
        public async Task Call_MapFunction_Once()
        {
            var dabataseName = nameof(Call_MapFunction_Once);

            var options = CommentTestUtil.GetOptions(dabataseName);

            var collectionOfComments = new List<Comment>();

            var mappingProviderMock = new Mock<IMappingProvider>();
            mappingProviderMock
                .Setup(x => x.MapTo<ICollection<CommentViewModel>>(It.IsAny<List<Comment>>()))
                .Callback<object>(inputargs => collectionOfComments = inputargs as List<Comment>);

            using (var arrangeContext = new MovieManagementContext(options))
            {
                arrangeContext.Comments.Add(new Comment()
                {
                    Text = "Very interesting. Would love to see it!",
                    Title = "Avengers EndGame"
                });
                arrangeContext.Comments.Add(new Comment()
                {
                    Text = "Every Marvel movie has achieved revenue of over 100million dollars",
                    Title = "Marvel movies are blockbusters"
                });
                await arrangeContext.SaveChangesAsync();
            }

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new CommentService(actAndAssertContext, mappingProviderMock.Object);
                await sut.GetAllComments();

                mappingProviderMock.Verify(m => m.MapTo<ICollection<CommentViewModel>>(collectionOfComments), Times.Once);
            }
        }
    }
}
