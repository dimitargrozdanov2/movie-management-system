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

namespace MovieManagement.Tests.Services.NewsServiceTests
{
    [TestClass]
    public class CreateNews_Should
    {
        [TestMethod]
        public async Task Throw_WhenNews_DoExist()
        {
            var dabataseName = nameof(Throw_WhenNews_DoExist);

            var options = NewsTestUtils.GetOptions(dabataseName);

            NewsTestUtils.FillContextWithNews(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            DateTime createdOn = DateTime.Now;
            string newsTitle = "Spider-Man Far From Home soon in cinemas";
            string text = " Spider-Man: Far From Home will be released in theaters on July 5, 2019";
            string imageUrl = "anyimage.jpg";

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new NewsService(actAndAssertContext, mappingProviderMock.Object);


                await Assert.ThrowsExceptionAsync<EntityAlreadyExistsException>(
                    async () => await sut.CreateNewsAsync(createdOn, newsTitle, text, imageUrl));
            }
        }

        [TestMethod]
        public async Task CreateNews_WhenAllParametersAreValid()
        {
            var dabataseName = nameof(CreateNews_WhenAllParametersAreValid);

            var options = NewsTestUtils.GetOptions(dabataseName);

            var mappingProviderMock = new Mock<IMappingProvider>();

            DateTime createdOn = DateTime.Now;
            string newsTitle = "Spider-Man Far From Home soon in cinemas";
            string text = " Spider-Man: Far From Home will be released in theaters on July 5, 2019";
            string imageUrl = "anyimage.jpg";

            using (var arrangeContext = new MovieManagementContext(options))
            {
                var sut = new NewsService(arrangeContext, mappingProviderMock.Object);


                await sut.CreateNewsAsync(createdOn, newsTitle, text, imageUrl);

                arrangeContext.SaveChanges();
            }

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                Assert.IsTrue(actAndAssertContext.News.Count() == 1);
                Assert.IsTrue(actAndAssertContext.News.Any(m => m.Title == newsTitle));
            }
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel()
        {
            var dabataseName = nameof(ReturnCorrectViewModel);

            var options = NewsTestUtils.GetOptions(dabataseName);

            var mappingProviderMock = new Mock<IMappingProvider>();

            mappingProviderMock.Setup(x => x.MapTo<NewsViewModel>(It.IsAny<News>())).Returns(new NewsViewModel());

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new NewsService(actAndAssertContext, mappingProviderMock.Object);

                DateTime createdOn = DateTime.Now;
                string newsTitle = "Spider-Man Far From Home soon in cinemas";
                string text = " Spider-Man: Far From Home will be released in theaters on July 5, 2019";
                string imageUrl = "anyimage.jpg";

                var result = await sut.CreateNewsAsync(createdOn, newsTitle, text, imageUrl);

                Assert.IsInstanceOfType(result, typeof(NewsViewModel));
            }
        }
    }
}

