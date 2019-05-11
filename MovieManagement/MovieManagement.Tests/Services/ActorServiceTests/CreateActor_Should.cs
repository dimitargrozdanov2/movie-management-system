using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Infrastructure;
using MovieManagement.Services;
using MovieManagement.Services.Exceptions;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Tests.Services.ActorServiceTests
{
    [TestClass]
    public class CreateActor_Should
    {
        [TestMethod]
        public async Task Throw_WhenActor_DoesExists()
        {
            var dabataseName = nameof(Throw_WhenActor_DoesExists);

            var options = ActorTestUtils.GetOptions(dabataseName);

            ActorTestUtils.FillContextWithActors(options);

            var mappingProviderMock = new Mock<IMappingProvider>();

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new ActorService(actAndAssertContext, mappingProviderMock.Object);

                string actorName = "Julia Roberts";

                await Assert.ThrowsExceptionAsync<EntityAlreadyExistsException>(
                    async () => await sut.CreateActorAsync(actorName));
            }
        }

        [TestMethod]
        public async Task AddNewActor_WhenAllParametersAreValid()
        {
            var dabataseName = nameof(AddNewActor_WhenAllParametersAreValid);

            var options = ActorTestUtils.GetOptions(dabataseName);

            var mappingProviderMock = new Mock<IMappingProvider>();

            string actorName = "Michael Jordan";

            using (var arrangeContext = new MovieManagementContext(options))
            {
                var sut = new ActorService(arrangeContext, mappingProviderMock.Object);


                await sut.CreateActorAsync(actorName);

                arrangeContext.SaveChanges();
            }

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                Assert.IsTrue(actAndAssertContext.Actors.Count() == 1);
                Assert.IsTrue(actAndAssertContext.Actors.Any(m => m.Name == actorName));
            }


        }
        [TestMethod]
        public async Task ReturnCorrectViewModel()
        {
            var dabataseName = nameof(ReturnCorrectViewModel);

            var options = ActorTestUtils.GetOptions(dabataseName);

            var mappingProviderMock = new Mock<IMappingProvider>();

            mappingProviderMock.Setup(x => x.MapTo<ActorViewModel>(It.IsAny<Actor>())).Returns(new ActorViewModel());

            using (var actAndAssertContext = new MovieManagementContext(options))
            {
                var sut = new ActorService(actAndAssertContext, mappingProviderMock.Object);

                string actorName = "Michael Jordan";

                var result = await sut.CreateActorAsync(actorName);

                Assert.IsInstanceOfType(result, typeof(ActorViewModel));
            }
        }
    }
}
