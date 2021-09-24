using Application.Meters.Commands.DeleteMeter;
using Application.Meters.Commands.UpdateMeter;
using Application.Common.Exceptions;
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

    public class UpdateMeterDetailsTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoListId()
        {
            var command = new UpdateMeterDetailsCommand
            {
                Id = 99,
                SerialNumber = "12121212"                
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateMeterDetails()
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

            var updateCommand = new UpdateMeterDetailsCommand()
            {
                Id = meterId,
                SerialNumber = "2222221"
            };

            await SendAsync(updateCommand);

            var meter = await FindAsync<Meter>(meterId);

            meter.SerialNumber.Should().Be("2222221");
        }
    }
}