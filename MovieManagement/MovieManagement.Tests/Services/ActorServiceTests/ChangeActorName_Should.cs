using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Data;
using MovieManagement.Infrastructure;
using MovieManagement.Services;
using MovieManagement.Services.Exceptions;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Services.ActorServiceTests
{
    [TestClass]
    public class ChangeActorName_Should
    {
        [TestMethod]
        public async Task Throw_WhenActor_DoesNotExists()
        {
            var dabataseName = nameof(Throw_WhenActor_DoesNotExists);

            var options = ActorTestUtils.GetOptions(dabataseName);

            ActorTestUtils.FillContextWithActors(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            ActorViewModel actorViewModel = null;

            // we use new instance of that context, but it has the data already saved.
            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new ActorService(actAndAssertContext, mappingProviderMock.Object);
                string actorName = "Jo";

                await Assert.ThrowsExceptionAsync<EntityInvalidException>(
                    async () => await sut.ChangeActorNameAsync(actorName, actorViewModel));
            }
        }

        [TestMethod]
        public async Task ChangeActorName_WithCorrectInformation()
        {
            var dabataseName = nameof(Throw_WhenActor_DoesNotExists);

            var options = ActorTestUtils.GetOptions(dabataseName);

            ActorTestUtils.FillContextWithActors(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            string newActorName = "Joe Dope";

            var actorViewModel = new ActorViewModel()
            {
                Name = newActorName
            };

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new ActorService(actAndAssertContext, mappingProviderMock.Object);
                string oldActorName = "Julia Roberts";

                await sut.ChangeActorNameAsync(oldActorName, actorViewModel);

                Assert.IsTrue(await actAndAssertContext.Actors.AnyAsync(m => m.Name == newActorName));
            }
        }
    }
}
