using Application.Buildings.Commands.DeleteBuilding;
using Application.Common.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using WaterMeterManager.Application.Buildings.Commands.CreateBuilding;
using WaterMeterManager.Domain.Entities;

namespace Application.Integration.Tests.Buildings.Commands
{
    using static Testing;

    public class DeleteBuildingTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoListId()
        {
            var command = new DeleteBuildingCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteBuilding()
        {
            var buildingId = await SendAsync(new CreateBuildingCommand()
            {
                City = "20"
            });

            var command = new DeleteBuildingCommand()
            {
                Id = buildingId
            };

            var building = await FindAsync<Building>(buildingId);

            building.Street.Should().BeNull();
        }
    }
}