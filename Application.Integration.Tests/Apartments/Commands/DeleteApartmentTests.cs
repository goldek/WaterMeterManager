using Application.Apartments.Commands.DeleteApartment;
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

    public class DeleteApartmentTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoListId()
        {
            var command = new DeleteApartmentCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteApartment()
        {
            var createBuildingCommand = new CreateBuildingCommand
            {
                City = "Opole"
            };

            var buildingId = await SendAsync(createBuildingCommand);

            var apartmentId = await SendAsync(new CreateApartmentCommand()
            {
                BuildingId = buildingId,
                Number = "20"
            });

            var command = new DeleteApartmentCommand()
            {
                Id = apartmentId
            };

            await SendAsync(command);

            var apartment = await FindAsync<Apartment>(apartmentId);

            apartment.Should().BeNull();
        }
    }
}