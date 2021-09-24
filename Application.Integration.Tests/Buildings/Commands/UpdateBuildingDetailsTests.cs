using Application.Buildings.Commands.DeleteBuilding;
using Application.Buildings.Commands.UpdateBuilding;
using Application.Common.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using WaterMeterManager.Application.Buildings.Commands.CreateBuilding;
using WaterMeterManager.Domain.Entities;

namespace Application.Integration.Tests.Buildings.Commands
{
    using static Testing;

    public class UpdateBuildingDetailsTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoListId()
        {
            var command = new UpdateBuildingDetailsCommand
            {
                Id = 99,
                Number = "sdsdsd"
                
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateBuildingDetails()
        {
            var buildingId = await SendAsync(new CreateBuildingCommand()
            {
                City = "Kielce"
            });

            var command = new UpdateBuildingDetailsCommand()
            {
                Id = buildingId,
                City = "Krakow"                
            };

            await SendAsync(command);

            var building = await FindAsync<Building>(buildingId);

            building.City.Should().Be("Krakow");
        }
    }
}