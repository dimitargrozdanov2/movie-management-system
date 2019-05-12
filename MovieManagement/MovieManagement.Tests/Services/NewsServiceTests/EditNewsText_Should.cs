using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Data;
using MovieManagement.Infrastructure;
using MovieManagement.Services;
using MovieManagement.Services.Exceptions;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Services.NewsServiceTests
{
    [TestClass]
    public class EditNewsText_Should
    {
        [TestMethod]
        public async Task Throw_WhenNews_DoesNotExists()
        {
            var dabataseName = nameof(Throw_WhenNews_DoesNotExists);

            var options = NewsTestUtils.GetOptions(dabataseName);

            NewsTestUtils.FillContextWithNews(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            NewsViewModel newsViewModel = null;

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new NewsService(actAndAssertContext, mappingProviderMock.Object);
                string newsTitle = "Michael Jordan received an Oscar for Creed II";

                await Assert.ThrowsExceptionAsync<EntityInvalidException>(
                    async () => await sut.EditNewsTextAsync(newsTitle, newsViewModel));
            }
        }

        [TestMethod]
        public async Task EditNewsText_WithCorrectInformation()
        {
            var dabataseName = nameof(Throw_WhenNews_DoesNotExists);

            var options = NewsTestUtils.GetOptions(dabataseName);

            NewsTestUtils.FillContextWithNews(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            string newsTitle = "Spider-Man Far From Home soon in cinemas";

            string changedNewsText = "Spider-Man tickets have already been sold out due to huge interest";

            var newsViewModel = new NewsViewModel()
            {
                Text = changedNewsText
            };

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new NewsService(actAndAssertContext, mappingProviderMock.Object);

                await sut.EditNewsTextAsync(newsTitle, newsViewModel);

                Assert.IsTrue(await actAndAssertContext.News.AnyAsync(m => m.Text == changedNewsText));
            }
        }
    }
}
