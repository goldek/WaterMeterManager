using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using WaterMeterManager.Application.Meters.Commands.CreateMeter;
using WaterMeterManager.Application.Buildings.Commands.CreateBuilding;
using WaterMeterManager.Domain.Entities;
using WaterMeterManager.Application.Apartments.Commands.CreateApartment;

namespace Application.Integration.Tests.Meters.Commands
{
    using static Testing;

    public class CreateMeterTests : TestBase
    {
        [Test]
        public async Task ShouldCreateMeter()
        {
            var createBuildingCommand = new CreateBuildingCommand
            {
                City = "Opole"
            };

            var buildingId = await SendAsync(createBuildingCommand);

            var createApartmentCommand = new CreateApartmentCommand
            {
                BuildingId = buildingId,
                Number = "21"
            };

            var apartmentId = await SendAsync(createApartmentCommand);

            var command = new CreateMeterCommand()
            {
                ApartmentId = apartmentId,
                SerialNumber = "12121212"
            };

            var id = await SendAsync(command);

            var meter = await FindAsync<Meter>(id);

            meter.Should().NotBeNull();
            meter.MeterId.Should().Be(id);
            meter.SerialNumber.Should().Be("12121212");
        }
    }
}