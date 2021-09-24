using Application.Buildings.Commands.DeleteBuilding;
using Application.Buildings.Commands.UpdateBuilding;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WaterMeterManager.Application.Buildings.Commands.CreateBuilding;
using WaterMeterManager.Application.Buildings.Queries.GetBuildings;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterManager.WebUI.Controllers
{
    public class BuildingsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Building>>> GetBuildings([FromQuery] GetBuildingsListQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBuildingCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateBuildingDetailsCommand command)
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
            await Mediator.Send(new DeleteBuildingCommand { Id = id });

            return NoContent();
        }
    }
}