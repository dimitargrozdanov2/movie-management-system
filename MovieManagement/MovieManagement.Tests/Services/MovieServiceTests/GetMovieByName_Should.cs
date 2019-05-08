using Microsoft.EntityFrameworkCore;
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
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Services.MovieServiceTests
{
    [TestClass]
    public class GetMovieByName_Should
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
                    async () => await sut.GetMovieByNameAsync(movieName));
            }
        }

        [TestMethod]
        public async Task Return_CorrectMovie()
        {
            var dabataseName = nameof(Return_CorrectMovie);

            var options = MovieTestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            MovieTestUtils.FillContextWithActorsMoviesAndGenres(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            Movie movie = null;
            mappingProviderMock
                .Setup(m => m.MapTo<MovieViewModel>(It.IsAny<Movie>()))
                .Callback<object>(inputargs => movie = inputargs as Movie);

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string movieName = "Spiderman";

                await sut.GetMovieByNameAsync(movieName);

                Assert.AreEqual(movieName, movie.Name);
            }
        }

        [TestMethod]
        public async Task Call_MapFunction_Once()
        {
            var dabataseName = nameof(Return_CorrectMovie);

            var options = MovieTestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            MovieTestUtils.FillContextWithActorsMoviesAndGenres(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            Movie movie = null;
            mappingProviderMock
                .Setup(m => m.MapTo<MovieViewModel>(It.IsAny<Movie>()))
                .Callback<object>(inputargs => movie = inputargs as Movie);

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string movieName = "Spiderman";

                await sut.GetMovieByNameAsync(movieName);

                mappingProviderMock.Verify(m => m.MapTo<MovieViewModel>(movie), Times.Once);
            }
        }
    }
}
