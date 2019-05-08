using Microsoft.EntityFrameworkCore;
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

namespace MovieManagement.Tests.Services.MovieServiceTests
{
    [TestClass]
    public class DeleteMovie_Should
    {
        [TestMethod]
        public async Task Throw_WhenMovie_DoesNotExists()
        {
            var dabataseName = nameof(Throw_WhenMovie_DoesNotExists);

            var options = MovieTestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            MovieTestUtils.FillContextWithActorsMoviesAndGenres(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            // we use new instance of that context, but it has the data already saved.
            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string movieName = "TestInvalidMovie";

                await Assert.ThrowsExceptionAsync<EntityInvalidException>(
                    async () => await sut.DeleteMovieAsync(movieName));
            }
        }

        [TestMethod]
        public async Task Flag_MovieAsDeleted()
        {
            var dabataseName = nameof(Flag_MovieAsDeleted);

            var options = MovieTestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            MovieTestUtils.FillContextWithActorsMoviesAndGenres(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            // we use new instance of that context, but it has the data already saved.
            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string movieName = "Spiderman";

                var movie = await actAndAssertContext.Movies.FirstOrDefaultAsync(m => m.Name == movieName);

                Assert.IsTrue(movie.IsDeleted == false);

                await sut.DeleteMovieAsync(movieName);

                Assert.IsTrue(await actAndAssertContext.Movies.AnyAsync(m => m.Name == movieName) == false);
            }
        }
    }
}
