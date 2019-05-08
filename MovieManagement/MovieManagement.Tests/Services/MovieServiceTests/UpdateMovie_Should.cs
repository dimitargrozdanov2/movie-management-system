using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Infrastructure;
using MovieManagement.Services;
using MovieManagement.Services.Exceptions;
using MovieManagement.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Services.MovieServiceTests
{
    [TestClass]
    public class UpdateMovie_Should
    {
        [TestMethod]
        public async Task Throw_WhenMovie_DoesNotExists()
        {
            var dabataseName = nameof(Throw_WhenMovie_DoesNotExists);

            var options = MovieTestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            MovieTestUtils.FillContextWithActorsMoviesAndGenres(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            MovieViewModel movieViewModel = null;

            // we use new instance of that context, but it has the data already saved.
            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string movieName = "TestInvalidMovie";

                await Assert.ThrowsExceptionAsync<EntityInvalidException>(
                    async () => await sut.UpdateMovieAsync(movieName, movieViewModel));
            }
        }

        [TestMethod]
        public async Task UpdateMovie_WithCorrectInformation()
        {
            var dabataseName = nameof(UpdateMovie_WithCorrectInformation);

            var options = MovieTestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            MovieTestUtils.FillContextWithActorsMoviesAndGenres(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            string newMovieName = "NewSpiderman";
            int duration = 120;
            string storyline = "NewStoryline";
            string director = "NewDirector";
            string imageUrl = "NewImageUrl";

            var movieViewModel = new MovieViewModel()
            {
                Name = newMovieName,
                Duration = duration,
                Storyline = storyline,
                Director = director,
                ImageUrl = imageUrl
            };

            // we use new instance of that context, but it has the data already saved.
            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string oldMovieName = "Spiderman";

                await sut.UpdateMovieAsync(oldMovieName, movieViewModel);

                Assert.IsTrue(await actAndAssertContext.Movies.AnyAsync(m => m.Name == newMovieName));
                Assert.IsTrue(await actAndAssertContext.Movies.AnyAsync(m => m.Duration == duration));
                Assert.IsTrue(await actAndAssertContext.Movies.AnyAsync(m => m.Storyline == storyline));
                Assert.IsTrue(await actAndAssertContext.Movies.AnyAsync(m => m.Director == director));
                Assert.IsTrue(await actAndAssertContext.Movies.AnyAsync(m => m.ImageUrl == imageUrl));
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

            string newMovieName = "NewSpiderman";
            int duration = 120;
            string storyline = "NewStoryline";
            string director = "NewDirector";
            string imageUrl = "NewImageUrl";

            var movieViewModel = new MovieViewModel()
            {
                Name = newMovieName,
                Duration = duration,
                Storyline = storyline,
                Director = director,
                ImageUrl = imageUrl
            };

            // we use new instance of that context, but it has the data already saved.
            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string oldMovieName = "Spiderman";

                await sut.UpdateMovieAsync(oldMovieName, movieViewModel);

                mappingProviderMock.Verify(m => m.MapTo<MovieViewModel>(movieReturned), Times.Once);
            }
        }
    }
}
