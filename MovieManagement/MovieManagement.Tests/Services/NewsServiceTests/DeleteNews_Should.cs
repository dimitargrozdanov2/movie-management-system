using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Data;
using MovieManagement.Infrastructure;
using MovieManagement.Services;
using MovieManagement.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Services.NewsServiceTests
{
    [TestClass]
    public class DeleteNews_Should
    {
        [TestMethod]
        public async Task Throw_WhenNews_DoNotExist()
        {
            var dabataseName = nameof(Throw_WhenNews_DoNotExist);

            var options = NewsTestUtils.GetOptions(dabataseName);

            NewsTestUtils.FillContextWithNews(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            string newsTitle = "BatMan is back!";

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new NewsService(actAndAssertContext, mappingProviderMock.Object);


                await Assert.ThrowsExceptionAsync<EntityInvalidException>(
                    async () => await sut.DeleteNews(newsTitle));
            }
        }

        [TestMethod]
        public async Task Delete_NewsSuccesfully()
        {
            var dabataseName = nameof(Delete_NewsSuccesfully);

            var options = NewsTestUtils.GetOptions(dabataseName);

            NewsTestUtils.FillContextWithNews(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new NewsService(actAndAssertContext, mappingProviderMock.Object);
                string newsTitle = "Spider-Man Far From Home soon in cinemas";

                Assert.IsTrue(actAndAssertContext.News.Count() == 1);

                await sut.DeleteNews(newsTitle);

                Assert.IsTrue(actAndAssertContext.News.Count() == 0);
            }
        }
    }
}
