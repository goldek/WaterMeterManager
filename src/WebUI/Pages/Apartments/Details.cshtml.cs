using Application.Apartments.Queries.GetApartment;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterManager.WebUI.Pages.Apartments
{
    public class DetailsModel : PageModelWithMediator

    {
        public Apartment Apartment { get; set; }
        public List<Meter> Meters { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Apartment = await Mediator.Send(new GetApartmentQuery() { Id = id });
            if (Apartment == null)
            {
                return NotFound();
            }

            Meters = (List<Meter>)Apartment.Meters;
            return Page();
        }
    }
}