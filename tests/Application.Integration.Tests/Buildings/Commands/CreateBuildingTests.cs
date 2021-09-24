using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using WaterMeterManager.Application.Buildings.Commands.CreateBuilding;
using WaterMeterManager.Domain.Entities;

namespace Application.Integration.Tests.Buildings.Commands
{
    using static Testing;

    public class CreateBuildingTests : TestBase
    {
        [Test]
        public async Task ShouldCreateBuilding()
        {
            var command = new CreateBuildingCommand()
            {
                City = "Poznan",
                Street = "Krotka"
            };

            var id = await SendAsync(command);

            var building = await FindAsync<Building>(id);

            building.Should().NotBeNull();
            building.BuildingId.Should().Be(id);
            building.City.Should().Be("Poznan");
            building.Street.Should().Be("Krotka");
        }
    }
}