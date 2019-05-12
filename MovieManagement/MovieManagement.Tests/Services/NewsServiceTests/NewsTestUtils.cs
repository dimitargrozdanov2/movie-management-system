using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieManagement.Data;
using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Tests.Services.NewsServiceTests
{
    public class NewsTestUtils
    {
        public static DbContextOptions<MovieManagementContext> GetOptions(string databaseName)
        {

            var serviceCollection = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            return new DbContextOptionsBuilder<MovieManagementContext>()
                .UseInMemoryDatabase(databaseName)
                .UseInternalServiceProvider(serviceCollection)
                .Options;
        }

        public static MovieManagementContext FillContextWithNews(DbContextOptions<MovieManagementContext> options)
        {
            var context = new MovieManagementContext(options);

            context.News.Add(new News()
            {
                Id = "4ac30bde - f507 - 48f2 - 9dd4 - 5cda4a6b539e",
                Title = "Spider-Man Far From Home soon in cinemas",
                Text = " Spider-Man: Far From Home will be released in theaters on July 5, 2019",
                ImageUrl = "anyimage.jpg"
            });

            context.SaveChanges();

            return context;
        }
    }
}
