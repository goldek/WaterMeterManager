using Application.Apartments.Commands.DeleteApartment;
using Application.Apartments.Commands.UpdateApartment;
using Application.Apartments.Queries.GetApartment;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WaterMeterManager.Application.Apartments.Commands.CreateApartment;
using WaterMeterManager.Application.Apartments.Queries.GetApartments;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterManager.WebUI.Controllers
{
    public class ApartmentsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Apartment>>> GetApartments([FromQuery] GetApartmentsListQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Apartment>> GetApartment(int id)
        {
            return await Mediator.Send(new GetApartmentQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateApartmentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateApartmentDetailsCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteApartmentCommand { Id = id });

            return NoContent();
        }
    }
}