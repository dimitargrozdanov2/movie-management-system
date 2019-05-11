﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class CreateMovie_Should
    {
        [TestMethod]
        public async Task Throw_WhenMovie_DoesExists()
        {
            var dabataseName = nameof(Throw_WhenMovie_DoesExists);

            var options = MovieTestUtils.GetOptions(dabataseName);

            // We fill the context with data and save it.
            MovieTestUtils.FillContextWithActorsMoviesAndGenres(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            // we use new instance of that context, but it has the data already saved.
            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string movieName = "Spiderman";
                int duration = 90;
                string director = "TestDirector";
                string storyline = "TestStoryline";
                string imageUrl = "TestImageUrl";
                string genreName = "TestGenre";

                await Assert.ThrowsExceptionAsync<EntityAlreadyExistsException>(
                    async () => await sut.CreateMovieAsync(movieName, duration, storyline, director, imageUrl, genreName));
            }
        }

        [TestMethod]
        public async Task Throw_WhenGenreIsNotFound()
        {
            var dabataseName = nameof(Throw_WhenGenreIsNotFound);
            var options = MovieTestUtils.GetOptions(dabataseName);

            var mappingProviderMock = new Mock<IMappingProvider>();

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string movieName = "Spiderman";
                int duration = 90;
                string director = "TestDirector";
                string storyline = "TestStoryline";
                string imageUrl = "TestImageUrl";
                string genreName = "TestGenre";

                await Assert.ThrowsExceptionAsync<EntityInvalidException>(
                    async () => await sut.CreateMovieAsync(movieName, duration, storyline, director, imageUrl, genreName));
            }
        }

        [TestMethod]
        public async Task AddNewMovie_WhenAllParametersAreValid()
        {
            var dabataseName = nameof(AddNewMovie_WhenAllParametersAreValid);
            var options = MovieTestUtils.GetOptions(dabataseName);

            MovieTestUtils.FillContextWithGenre(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            string movieName = "Spiderman";
            int duration = 90;
            string director = "TestDirector";
            string storyline = "TestStoryline";
            string imageUrl = "TestImageUrl";
            string genreName = "Comedy";

            using (var arrangeContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(arrangeContext, mappingProviderMock.Object);

                await sut.CreateMovieAsync(movieName, duration, storyline, director, imageUrl, genreName);

                arrangeContext.SaveChanges();
            }

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                Assert.IsTrue(actAndAssertContext.Movies.Count() == 1);
                Assert.IsTrue(actAndAssertContext.Movies.Any(m => m.Name == movieName));
            }
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel()
        {
            // Arrange
            var dabataseName = nameof(ReturnCorrectViewModel);
            var options = MovieTestUtils.GetOptions(dabataseName);

            MovieTestUtils.FillContextWithGenre(options);

            // setting up the automapper to be able to map the object from Movie to MovieViewModel
            var mappingProviderMock = new Mock<IMappingProvider>();
            mappingProviderMock.Setup(x => x.MapTo<MovieViewModel>(It.IsAny<Movie>())).Returns(new MovieViewModel());

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new MovieService(actAndAssertContext, mappingProviderMock.Object);
                string movieName = "TestMovie";
                int duration = 90;
                string director = "TestDirector";
                string storyline = "TestStoryline";
                string imageUrl = "TestImageUrl";
                string genreName = "Comedy";

                var result = await sut.CreateMovieAsync(movieName, duration, storyline, director, imageUrl, genreName);

                Assert.IsInstanceOfType(result, typeof(MovieViewModel));
            }
        }
    }
}