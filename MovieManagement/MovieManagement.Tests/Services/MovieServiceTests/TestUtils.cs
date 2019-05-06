using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieManagement.Data;
using MovieManagement.DataModels;

namespace MovieManagement.Tests.Services.MovieServiceTests
{
    public class TestUtils
    {
        public static DbContextOptions<MovieManagementContext> GetOptions(string databaseName)
        {
            // we specify the context to use new servicecollection everytime its called
            // services like change tracker, etc.
            var serviceCollection = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            return new DbContextOptionsBuilder<MovieManagementContext>()
                .UseInMemoryDatabase(databaseName)
                .UseInternalServiceProvider(serviceCollection)
                .Options;
        }

        public static MovieManagementContext FillContextWithActorsMoviesAndGenres(DbContextOptions<MovieManagementContext> options)
        {
            var context = new MovieManagementContext(options);
            context.Genres.Add(new Genre() { Name = "Comedy", Id = "e9c7b88f-4ef4-4cb9-9acd-c65f6d94de60" });
            context.Genres.Add(new Genre() { Name = "Action", Id = "68e41878-d794-4f8b-8d06-8352193471c0" });

            context.Actors.Add(new Actor() { Name = "Johnny", Id = "c5f7f9f9-9052-4272-a8ae-0cbed323dd92" });
            context.Actors.Add(new Actor() { Name = "Deo", Id = "ce1eaffd-627c-4e0f-a24e-7433b263560f" });

            context.Movies.Add(new Movie()
            {
                Id = "3ff441e1-9a03-491d-b558-c3041625d51e",
                Name = "Spiderman",
                Duration = 90,
                Storyline = "This is very basic storyline for testing purpose",
                Director = "Johnny",
                GenreID = "e9c7b88f-4ef4-4cb9-9acd-c65f6d94de60",
                ImageUrl = "test image url.png"
            });
            context.Movies.Add(new Movie()
            {
                Id = "74359a62-5db2-47e3-9f12-7816500dc1e0",
                Name = "London",
                Duration = 90,
                Storyline = "This is very basic storyline for testing purpose too",
                Director = "BritishProduction",
                GenreID = "68e41878-d794-4f8b-8d06-8352193471c0",
                ImageUrl = "test image2 url.png"
            });

            // its enough to simply add the movieactor to the many to many table, not needed in the movie.
            context.MovieActor.Add(new MovieActor()
            {
                ActorId = "c5f7f9f9-9052-4272-a8ae-0cbed323dd92",
                MovieId = "3ff441e1-9a03-491d-b558-c3041625d51e"
            });
            context.SaveChanges();

            return context;
        }

        public static MovieManagementContext FillContextWithGenre(DbContextOptions<MovieManagementContext> options)
        {
            var context = new MovieManagementContext(options);
            context.Genres.Add(new Genre() { Name = "Comedy", Id = "d2cb7366-4a7e-4f79-9034-d05156b60dd2" });

            context.SaveChanges();

            return context;
        }
    }
}
