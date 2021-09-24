using System.Collections.Generic;
using System.Threading.Tasks;
using WaterMeterManager.Application.Meters.Queries.GetMeters;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterManager.WebUI.Pages.Apartments.Meters
{
    public class ListModel : PageModelWithMediator
    {
        public List<Meter> Meters { get; set; }

        public async Task OnGetAsync()
        {
            Meters = await Mediator.Send(new GetMetersListQuery());
        }
    }
}