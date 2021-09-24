using Application.Meters.Commands.DeleteMeter;
using Application.Meters.Commands.UpdateMeter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WaterMeterManager.Application.Meters.Commands.CreateMeter;
using WaterMeterManager.Application.Meters.Queries.GetMeters;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterManager.WebUI.Controllers
{
    public class MetersController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Meter>>> GetMeters([FromQuery] GetMetersListQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateMeterCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateMeterDetailsCommand command)
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
            await Mediator.Send(new DeleteMeterCommand { Id = id });

            return NoContent();
        }
    }
}