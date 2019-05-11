using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Infrastructure;
using MovieManagement.Services;
using MovieManagement.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Services.MovieServiceTests
{
    [TestClass]
    public class Search_Should
    {
        [TestMethod]
        public async Task Return_TwoMoviesInCorrectOrderByDateCrated()
        {
            var dabataseName = nameof(Return_TwoMoviesInCorrectOrderByDateCrated);

            var options = MovieTestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            MovieTestUtils.FillContextWithActorsMoviesAndGenres(options);

            var collectionOfMovies = new List<Movie>();

            var mappingProviderMock = new Mock<IMappingProvider>();
            mappingProviderMock
                .Setup(x => x.MapTo<ICollection<MovieViewModel>>(It.IsAny<List<Movie>>()))
                .Callback<object>(inputargs => collectionOfMovies = inputargs as List<Movie>);

            using (var arrangeContext = new MovieManagementContext(options))
            {
                arrangeContext.Movies.Add(new Movie()
                {
                    Name = "VeryCoolMovie",
                    Duration = 90,
                    Director = "TestDirector",
                    Storyline = "TestStoryline",
                    ImageUrl = "TestImageUrl",
                    GenreID = "e9c7b88f-4ef4-4cb9-9acd-c65f6d94de60"
                });
                arrangeContext.Movies.Add(new Movie()
                {
                    Name = "NotThatCoolMovie",
                    Duration = 90,
                    Director = "TestDirector",
                    Storyline = "TestStoryline",
                    ImageUrl = "TestImageUrl",
                    GenreID = "e9c7b88f-4ef4-4cb9-9acd-c65f6d94de60"
                });
                await arrangeContext.SaveChangesAsync();
            }

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);

                string partOfTitle = "Cool";
                await sut.SearchAsync(partOfTitle);

                Assert.AreEqual(2, collectionOfMovies.Count());

                Assert.IsTrue(collectionOfMovies.Any(x => x.Name == "VeryCoolMovie"));
                Assert.IsTrue(collectionOfMovies.Any(x => x.Name == "NotThatCoolMovie"));
            }
        }

        [TestMethod]
        public async Task Call_MapFunction_Once()
        {
            var dabataseName = nameof(Return_TwoMoviesInCorrectOrderByDateCrated);

            var options = MovieTestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            MovieTestUtils.FillContextWithActorsMoviesAndGenres(options);

            var collectionOfMovies = new List<Movie>();

            var mappingProviderMock = new Mock<IMappingProvider>();
            mappingProviderMock
                .Setup(x => x.MapTo<ICollection<MovieViewModel>>(It.IsAny<List<Movie>>()))
                .Callback<object>(inputargs => collectionOfMovies = inputargs as List<Movie>);

            using (var arrangeContext = new MovieManagementContext(options))
            {
                arrangeContext.Movies.Add(new Movie()
                {
                    Name = "VeryCoolMovie",
                    Duration = 90,
                    Director = "TestDirector",
                    Storyline = "TestStoryline",
                    ImageUrl = "TestImageUrl",
                    GenreID = "e9c7b88f-4ef4-4cb9-9acd-c65f6d94de60"
                });
                arrangeContext.Movies.Add(new Movie()
                {
                    Name = "NotThatCoolMovie",
                    Duration = 90,
                    Director = "TestDirector",
                    Storyline = "TestStoryline",
                    ImageUrl = "TestImageUrl",
                    GenreID = "e9c7b88f-4ef4-4cb9-9acd-c65f6d94de60"
                });
                await arrangeContext.SaveChangesAsync();
            }

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);

                string partOfTitle = "Cool";
                await sut.SearchAsync(partOfTitle);

                mappingProviderMock.Verify(m => m.MapTo<ICollection<MovieViewModel>>(collectionOfMovies), Times.Once);
            }
        }
    }
}