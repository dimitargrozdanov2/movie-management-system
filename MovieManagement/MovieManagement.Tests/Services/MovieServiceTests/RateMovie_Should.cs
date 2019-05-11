using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Infrastructure;
using MovieManagement.Services;
using MovieManagement.Services.Exceptions;
using MovieManagement.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Services.MovieServiceTests
{
    [TestClass]
    public class RateMovie_Should
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
                string movieName = "InvalidName";

                await Assert.ThrowsExceptionAsync<EntityInvalidException>(
                    async () => await sut.RateMovieAsync(movieName, 1));
            }
        }

        [TestMethod]
        public async Task Add_RatingSuccessfully()
        {
            var dabataseName = nameof(Add_RatingSuccessfully);

            var options = MovieTestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            MovieTestUtils.FillContextWithActorsMoviesAndGenres(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            // we use new instance of that context, but it has the data already saved.
            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string movieName = "Spiderman";
                double rating = 10;

                var movie = await actAndAssertContext.Movies.FirstOrDefaultAsync(m => m.Name == movieName);

                Assert.IsTrue(movie.Rating == 0);

                await sut.RateMovieAsync(movieName, rating);

                Assert.IsTrue(actAndAssertContext.Movies.FirstOrDefault(m => m.Name == movieName).Rating == 10);
            }
        }

        [TestMethod]
        public async Task Add_VotesCountSuccessfully()
        {
            var dabataseName = nameof(Add_VotesCountSuccessfully);

            var options = MovieTestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            MovieTestUtils.FillContextWithActorsMoviesAndGenres(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            // we use new instance of that context, but it has the data already saved.
            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string movieName = "Spiderman";
                double rating = 10;

                var movie = await actAndAssertContext.Movies.FirstOrDefaultAsync(m => m.Name == movieName);

                Assert.IsTrue(movie.VotesCount == 0);

                await sut.RateMovieAsync(movieName, rating);

                Assert.IsTrue(actAndAssertContext.Movies.FirstOrDefault(m => m.Name == movieName).VotesCount == 1);
            }
        }

        [TestMethod]
        public async Task Call_MapFunction_Once()
        {
            var dabataseName = nameof(Call_MapFunction_Once);

            var options = MovieTestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            MovieTestUtils.FillContextWithActorsMoviesAndGenres(options);

            Movie movieReturned = null;

            var mappingProviderMock = new Mock<IMappingProvider>();
            mappingProviderMock
                .Setup(x => x.MapTo<MovieViewModel>(It.IsAny<Movie>()))
                .Callback<object>(inputargs => movieReturned = inputargs as Movie);

            // we use new instance of that context, but it has the data already saved.
            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string movieName = "Spiderman";
                double rating = 10;

                await sut.RateMovieAsync(movieName, rating);

                mappingProviderMock.Verify(m => m.MapTo<MovieViewModel>(movieReturned), Times.Once);
            }
        }
    }
}