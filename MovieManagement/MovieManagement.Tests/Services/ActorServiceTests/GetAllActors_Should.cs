using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Infrastructure;
using MovieManagement.Services;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Services.ActorServiceTests
{
    [TestClass]
    public class GetAllActors_Should
    {
        [TestMethod]
        public async Task Call_MapFunction_Once()
        {
            var dabataseName = nameof(Call_MapFunction_Once);

            var options = ActorTestUtils.GetOptions(dabataseName);

            var collectionOfActors = new List<Actor>();

            var mappingProviderMock = new Mock<IMappingProvider>();
            mappingProviderMock
                .Setup(x => x.MapTo<ICollection<ActorViewModel>>(It.IsAny<List<Actor>>()))
                .Callback<object>(inputargs => collectionOfActors = inputargs as List<Actor>);
            using (var arrangeContext = new MovieManagementContext(options))
            {
                arrangeContext.Actors.Add(new Actor()
                {
                    Name = "Mihail Bilalov"
                });
                arrangeContext.Actors.Add(new Actor()
                {
                    Name = "Zahari Baharov",
                });
                await arrangeContext.SaveChangesAsync();
            }

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new ActorService(actAndAssertContext, mappingProviderMock.Object);
                await sut.GetAllActorsAsync();
                //checks if the map function is called once with two added actors
                mappingProviderMock.Verify(m => m.MapTo<ICollection<ActorViewModel>>(collectionOfActors), Times.Once);
            }
        }
    }
}
