using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Data;
using MovieManagement.Infrastructure;
using MovieManagement.Services;
using MovieManagement.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Services.ActorServiceTests
{
    [TestClass]
    public class GetActorByName_Should
    {
        [TestMethod]
        public async Task Throw_WhenActor_DoesNotExists()
        {
            var dabataseName = nameof(Throw_WhenActor_DoesNotExists);

            var options = ActorTestUtils.GetOptions(dabataseName);

            ActorTestUtils.FillContextWithActors(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new ActorService(actAndAssertContext, mappingProviderMock.Object);
                string actorName = "Brat Pitt";

                await Assert.ThrowsExceptionAsync<EntityInvalidException>(
                    async () => await sut.GetActorByNameAsync(actorName));
            }
        }
    }
}
