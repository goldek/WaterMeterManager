using Application.Buildings.Queries.GetBuilding;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterManager.WebUI.Pages.Buildings
{
    public class DetailsModel : PageModelWithMediator

    {
        public Building Building { get; set; }
        public List<Apartment> Apartments { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Building = await Mediator.Send(new GetBuildingQuery() { Id = id });
            if (Building == null)
            {
                return NotFound();
            }

            Apartments = (List<Apartment>)Building.Apartments;
            return Page();
        }
    }
}