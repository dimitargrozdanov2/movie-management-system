using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieManagement.Data;
using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Tests.Services.ActorServiceTests
{
    public class ActorTestUtils
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

        public static MovieManagementContext FillContextWithActors(DbContextOptions<MovieManagementContext> options)
        {
            var context = new MovieManagementContext(options);

            context.Actors.Add(new Actor() { Name = "Julia Roberts", Id = "98121da1-d6b0-4248-84aa-75b7b931d9fc"});
       
            context.SaveChanges();

            return context;
        }

    }
}
