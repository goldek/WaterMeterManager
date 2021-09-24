using Application.Apartments.Commands.DeleteApartment;
using Application.Common.Exceptions;
using Application.Meters.Commands.DeleteMeter;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using WaterMeterManager.Application.Apartments.Commands.CreateApartment;
using WaterMeterManager.Application.Buildings.Commands.CreateBuilding;
using WaterMeterManager.Application.Meters.Commands.CreateMeter;
using WaterMeterManager.Domain.Entities;

namespace Application.Integration.Tests.Meters.Commands
{
    using static Testing;

    public class DeleteMeterTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoListId()
        {
            var command = new DeleteMeterCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteMeter()
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

            var createCommand = new CreateMeterCommand()
            {
                ApartmentId = apartmentId,
                SerialNumber = "12121212"
            };

            var meterId = await SendAsync(createCommand);

            var deleteCommand = new DeleteMeterCommand()
            {
                Id = meterId
            };

            await SendAsync(deleteCommand);

            var meter = await FindAsync<Meter>(meterId);

            meter.Should().BeNull();
        }
    }
}