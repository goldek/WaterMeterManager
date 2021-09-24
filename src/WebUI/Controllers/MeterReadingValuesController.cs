using Application.MeterReadingValues.Commands.DeleteMeterReadingValue;
using Application.MeterReadingValues.Commands.UpdateMeterReadingValue;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WaterMeterManager.Domain.Entities;
using WaterMeterManager.WebUI.Controllers;
using WaterMeterReadingValueManager.Application.MeterReadingValues.Commands.RegisterNewReadValue;
using WaterMeterReadingValueManager.Application.MeterReadingValues.Queries.GetMeterReadingValues;

namespace WaterMeterReadingValueManager.WebUI.Controllers
{
    public class MeterReadingValuesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<MeterReadingValue>>> GetMeterReadingValues([FromQuery] GetMeterReadingValuesListQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> RegisterNewReadValueCommand(RegisterNewReadValueCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateMeterReadingValueDetailsCommand command)
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
            await Mediator.Send(new DeleteMeterReadingValueCommand { Id = id });

            return NoContent();
        }
    }
}