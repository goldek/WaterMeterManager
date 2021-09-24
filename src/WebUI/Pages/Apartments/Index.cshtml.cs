using System.Collections.Generic;
using System.Threading.Tasks;
using WaterMeterManager.Application.Apartments.Queries.GetApartments;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterManager.WebUI.Pages.Apartments
{
    public class ListModel : PageModelWithMediator
    {
        public List<Apartment> Apartments { get; set; }

        public async Task OnGetAsync()
        {
            Apartments = await Mediator.Send(new GetApartmentsListQuery());
        }
    }
}