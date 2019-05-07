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
using System.Threading.Tasks;

namespace MovieManagement.Tests.Services.MovieServiceTests
{
    [TestClass]
    public class GetLatestMovies_Should
    {
        [TestMethod]
        public async Task Return_TwoMoviesInCorrectOrderByDateCrated()
        {
            var dabataseName = nameof(Return_TwoMoviesInCorrectOrderByDateCrated);

            var options = TestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            TestUtils.FillContextWithGenre(options);

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
                    //Rating = 5,
                    //VotesCount = 1,
                    Director = "TestDirector",
                    Storyline = "TestStoryline",
                    ImageUrl = "TestImageUrl",
                    GenreID = "e9c7b88f-4ef4-4cb9-9acd-c65f6d94de60",
                    CreatedOn = DateTime.Parse("3/20/2019 7:36:05 PM")
                });
                arrangeContext.Movies.Add(new Movie()
                {
                    Name = "SecondMovieTestName",
                    Duration = 90,
                    //Rating = 3,
                    //VotesCount = 1,
                    Director = "TestDirector",
                    Storyline = "TestStoryline",
                    ImageUrl = "TestImageUrl",
                    GenreID = "e9c7b88f-4ef4-4cb9-9acd-c65f6d94de60",
                    CreatedOn = DateTime.Parse("4/15/2019 7:36:05 PM")
                });
                await arrangeContext.SaveChangesAsync();
            }

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                await sut.GetLatestMoviesAsync();

                Assert.AreEqual(2, collectionOfMovies.Count());
                Assert.AreEqual("SecondMovieTestName", collectionOfMovies.FirstOrDefault().Name);
            }
        }

        [TestMethod]
        public async Task Call_MapFunction_Once()
        {
            var dabataseName = nameof(Call_MapFunction_Once);

            var options = TestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            TestUtils.FillContextWithGenre(options);

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
                    //Rating = 5,
                    //VotesCount = 1,
                    Director = "TestDirector",
                    Storyline = "TestStoryline",
                    ImageUrl = "TestImageUrl",
                    GenreID = "e9c7b88f-4ef4-4cb9-9acd-c65f6d94de60",
                    CreatedOn = DateTime.Parse("3/20/2019 7:36:05 PM")
                });
                arrangeContext.Movies.Add(new Movie()
                {
                    Name = "SecondMovieTestName",
                    Duration = 90,
                    //Rating = 3,
                    //VotesCount = 1,
                    Director = "TestDirector",
                    Storyline = "TestStoryline",
                    ImageUrl = "TestImageUrl",
                    GenreID = "e9c7b88f-4ef4-4cb9-9acd-c65f6d94de60",
                    CreatedOn = DateTime.Parse("4/15/2019 7:36:05 PM")
                });
                await arrangeContext.SaveChangesAsync();
            }

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                await sut.GetLatestMoviesAsync();

                mappingProviderMock.Verify(m => m.MapTo<ICollection<MovieViewModel>>(collectionOfMovies), Times.Once);
            }
        }

    }
}
