using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using WaterMeterManager.Application.Apartments.Commands.CreateApartment;
using WaterMeterManager.Application.Buildings.Commands.CreateBuilding;
using WaterMeterManager.Domain.Entities;

namespace Application.Integration.Tests.Apartments.Commands
{
    using static Testing;

    public class CreateApartmentTests : TestBase
    {
        [Test]
        public async Task ShouldCreateApartment()
        {
            var createBuildingCommand = new CreateBuildingCommand
            {
                City = "Opole"
            };

            var buildingId = await SendAsync(createBuildingCommand);

            var command = new CreateApartmentCommand()
            {
                BuildingId = buildingId,
                Number = "12a",
                Area = 22.4
            };

            var id = await SendAsync(command);

            var building = await FindAsync<Apartment>(id);

            building.Should().NotBeNull();
            building.ApartmentId.Should().Be(id);
            building.Number.Should().Be("12a");
            building.Area.Should().Be(22.4);
        }
    }
}