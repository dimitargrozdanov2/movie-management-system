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

namespace MovieManagement.Tests.Services.NewsServiceTests
{
    [TestClass]
    public class GetAllNews_Should
    {
        [TestMethod]
        public async Task Call_MapFunction_Once()
        {
            var dabataseName = nameof(Call_MapFunction_Once);

            var options = NewsTestUtils.GetOptions(dabataseName);

            var collectionOfNews = new List<News>();

            var mappingProviderMock = new Mock<IMappingProvider>();
            mappingProviderMock
                .Setup(x => x.MapTo<ICollection<NewsViewModel>>(It.IsAny<List<News>>()))
                .Callback<object>(inputargs => collectionOfNews = inputargs as List<News>);

            using (var arrangeContext = new MovieManagementContext(options))
            {
                arrangeContext.News.Add(new News()
                {
                    Id = "411855e5-579b-4a01-bddd-e5ade62da9f4",
                    Title = "New Spiderman",
                    Text = " Spider-Man: Far From Home will be released in theaters on July 5, 2019, in Bulgaria on 7th.",
                    ImageUrl = "testingimage.jpg"
                });
                arrangeContext.News.Add(new News()
                {
                    Id = "b6339180-2f36-44b7-89e9-2849b398cf17",
                    Title = "New Marvel movies",
                    Text = "After avengers there will be more marvel movies.",
                    ImageUrl = "testingimage2.jpg"
                });

                await arrangeContext.SaveChangesAsync();
            }

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new NewsService(actAndAssertContext, mappingProviderMock.Object);
                await sut.GetAllNewsAsync();

                mappingProviderMock.Verify(m => m.MapTo<ICollection<NewsViewModel>>(collectionOfNews), Times.Once);
            }
        }
    }
}
