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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Services.MovieServiceTests
{
    [TestClass]
    public class ManageActors_Should
    {
        [TestMethod]
        public async Task Throw_WhenMovie_DoesNotExists()
        {
            var dabataseName = nameof(Throw_WhenMovie_DoesNotExists);

            var options = TestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            TestUtils.FillContextWithActorsMoviesAndGenres(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            // we use new instance of that context, but it has the data already saved.
            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string movieName = "TestInvalidMovie";
                string actorName = "InvalidActor";

                await Assert.ThrowsExceptionAsync<EntityInvalidException>(
                    async () => await sut.ManageActorAsync(movieName, actorName));
            }
        }

        [TestMethod]
        public async Task Throw_WhenActor_DoesNotExists()
        {
            var dabataseName = nameof(Throw_WhenActor_DoesNotExists);

            var options = TestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            TestUtils.FillContextWithActorsMoviesAndGenres(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            // we use new instance of that context, but it has the data already saved.
            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string movieName = "Spiderman";
                string actorName = "InvalidActor";

                await Assert.ThrowsExceptionAsync<EntityInvalidException>(
                    async () => await sut.ManageActorAsync(movieName, actorName));
            }
        }

        [TestMethod]
        public async Task Correctly_AssignActorToMovie()
        {
            var dabataseName = nameof(Correctly_AssignActorToMovie);

            var options = TestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            TestUtils.FillContextWithActorsMoviesAndGenres(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            // we use new instance of that context, but it has the data already saved.
            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string movieName = "London";
                string actorName = "Deo";

                await sut.ManageActorAsync(movieName, actorName);

                Assert.IsTrue(actAndAssertContext
                    .Movies.FirstOrDefault(x => x.Name == movieName)
                    .MovieActor.Any(a => a.Actor?.Name == actorName));
            }
        }

        [TestMethod]
        public async Task Correctly_UnassignActorToMovie()
        {
            var dabataseName = nameof(Correctly_UnassignActorToMovie);

            var options = TestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            TestUtils.FillContextWithActorsMoviesAndGenres(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            // we use new instance of that context, but it has the data already saved.
            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                // Actor Johnny has already been assigned to this movie in the Test Utilies, upon db filling.
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string movieName = "Spiderman";
                string actorName = "Johnny";

                await sut.ManageActorAsync(movieName, actorName);

                Assert.IsTrue(actAndAssertContext
                    .Movies.FirstOrDefault(x => x.Name == movieName)
                    .MovieActor.Any(a => a.Actor?.Name == actorName) == false);
            }
        }

        [TestMethod]
        public async Task Call_MapFunction_Once()
        {
            var dabataseName = nameof(Call_MapFunction_Once);

            var options = TestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            TestUtils.FillContextWithActorsMoviesAndGenres(options);

            Movie movieReturned = null;

            var mappingProviderMock = new Mock<IMappingProvider>();
            mappingProviderMock
                .Setup(x => x.MapTo<MovieViewModel>(It.IsAny<Movie>()))
                .Callback<object>(inputargs => movieReturned = inputargs as Movie);

            // we use new instance of that context, but it has the data already saved.
            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string movieName = "London";
                string actorName = "Deo";

                await sut.ManageActorAsync(movieName, actorName);

                mappingProviderMock.Verify(m => m.MapTo<MovieViewModel>(movieReturned), Times.Once);
            }
        }
    }
}
