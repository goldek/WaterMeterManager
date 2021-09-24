using Application.Apartments.Commands.DeleteApartment;
using Application.Apartments.Commands.UpdateApartment;
using Application.Common.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using WaterMeterManager.Application.Apartments.Commands.CreateApartment;
using WaterMeterManager.Application.Buildings.Commands.CreateBuilding;
using WaterMeterManager.Domain.Entities;

namespace Application.Integration.Tests.Apartments.Commands
{
    using static Testing;

    public class UpdateApartmentDetailsTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoListId()
        {
            var command = new UpdateApartmentDetailsCommand
            {
                Id = 99,
                Number = "sdsdsd"
                
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateApartmentDetails()
        {
            var createBuildingCommand = new CreateBuildingCommand
            {
                City = "Opole"
            };

            var buildingId = await SendAsync(createBuildingCommand);

            var apartmentId = await SendAsync(new CreateApartmentCommand()
            {
                BuildingId = buildingId,
                Number = "12"
            });

            var command = new UpdateApartmentDetailsCommand()
            {
                Id = apartmentId,
                Number = "15"                
            };

            await SendAsync(command);

            var apartment = await FindAsync<Apartment>(apartmentId);

            apartment.Number.Should().Be("15");
        }
    }
}