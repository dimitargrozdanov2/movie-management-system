using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Infrastructure;
using MovieManagement.Services;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Services.MovieServiceTests
{
    [TestClass]
    public class GetTopRatedMovies_Should
    {
        [TestMethod]
        public async Task Return_TwoMoviesInCorrectOrderByRating()
        {
            var dabataseName = nameof(Return_TwoMoviesInCorrectOrderByRating);

            var options = MovieTestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            MovieTestUtils.FillContextWithGenre(options);

            var collectionOfMovies = new List<Movie>();

            var mappingProviderMock = new Mock<IMappingProvider>();
            mappingProviderMock
                .Setup(x => x.MapTo<ICollection<MovieViewModel>>(It.IsAny<List<Movie>>()))
                .Callback<object>(inputargs => collectionOfMovies = inputargs as List<Movie>);

            using (var arrangeContext = new MovieManagementContext(options))
            {
                arrangeContext.Movies.Add(new Movie()
                {
                    Name = "BestRatedMovieTest",
                    Duration = 90,
                    Rating = 5,
                    VotesCount = 1,
                    Director = "TestDirector",
                    Storyline = "TestStoryline",
                    ImageUrl = "TestImageUrl",
                    GenreID = "e9c7b88f-4ef4-4cb9-9acd-c65f6d94de60"
                });
                arrangeContext.Movies.Add(new Movie()
                {
                    Name = "SecondMovieTestName",
                    Duration = 90,
                    Rating = 3,
                    VotesCount = 1,
                    Director = "TestDirector",
                    Storyline = "TestStoryline",
                    ImageUrl = "TestImageUrl",
                    GenreID = "e9c7b88f-4ef4-4cb9-9acd-c65f6d94de60",
                });
                await arrangeContext.SaveChangesAsync();
            }

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                await sut.GetTopRatedMoviesAsync();

                Assert.AreEqual(2, collectionOfMovies.Count());
                Assert.AreEqual("BestRatedMovieTest", collectionOfMovies.FirstOrDefault().Name);
            }
        }

        [TestMethod]
        public async Task Call_MapFunction_Once()
        {
            var dabataseName = nameof(Call_MapFunction_Once);

            var options = MovieTestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            MovieTestUtils.FillContextWithGenre(options);

            var collectionOfMovies = new List<Movie>();

            var mappingProviderMock = new Mock<IMappingProvider>();
            mappingProviderMock
                .Setup(x => x.MapTo<ICollection<MovieViewModel>>(It.IsAny<List<Movie>>()))
                .Callback<object>(inputargs => collectionOfMovies = inputargs as List<Movie>);

            using (var arrangeContext = new MovieManagementContext(options))
            {
                arrangeContext.Movies.Add(new Movie()
                {
                    Name = "BestRatedMovieTest",
                    Duration = 90,
                    Rating = 5,
                    VotesCount = 1,
                    Director = "TestDirector",
                    Storyline = "TestStoryline",
                    ImageUrl = "TestImageUrl",
                    GenreID = "e9c7b88f-4ef4-4cb9-9acd-c65f6d94de60"
                });
                arrangeContext.Movies.Add(new Movie()
                {
                    Name = "SecondMovieTestName",
                    Duration = 90,
                    Rating = 3,
                    VotesCount = 1,
                    Director = "TestDirector",
                    Storyline = "TestStoryline",
                    ImageUrl = "TestImageUrl",
                    GenreID = "e9c7b88f-4ef4-4cb9-9acd-c65f6d94de60",
                });
                await arrangeContext.SaveChangesAsync();
            }

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                await sut.GetTopRatedMoviesAsync();

                mappingProviderMock.Verify(m => m.MapTo<ICollection<MovieViewModel>>(collectionOfMovies), Times.Once);
            }
        }
    }
}
