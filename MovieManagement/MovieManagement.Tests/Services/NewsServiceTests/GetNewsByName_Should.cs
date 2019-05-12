using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Data;
using MovieManagement.Infrastructure;
using MovieManagement.Services;
using MovieManagement.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Services.NewsServiceTests
{
    [TestClass]
    public class GetNewsByName_Should
    {
        [TestMethod]
        public async Task Throw_WhenNews_DoesNotExists()
        {
            var dabataseName = nameof(Throw_WhenNews_DoesNotExists);

            var options = NewsTestUtils.GetOptions(dabataseName);

            NewsTestUtils.FillContextWithNews(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new NewsService(actAndAssertContext, mappingProviderMock.Object);
                string newsTitle = "Michael Jordan received an Oscar for Creed II";

                await Assert.ThrowsExceptionAsync<EntityInvalidException>(
                    async () => await sut.GetNewsByNameAsync(newsTitle));
            }
        }
    }
}
