using Application.Meters.Queries.GetMeter;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterManager.WebUI.Pages.Apartments.Meters
{
    public class DetailsModel : PageModelWithMediator

    {
        public Meter Meter { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Meter = await Mediator.Send(new GetMeterQuery() { Id = id });
            if (Meter == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}