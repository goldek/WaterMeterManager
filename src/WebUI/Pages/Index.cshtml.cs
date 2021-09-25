using System.Collections.Generic;
using System.Threading.Tasks;
using WaterMeterManager.Application.Apartments.Queries.GetApartments;
using WaterMeterManager.Application.Buildings.Queries.GetBuildings;
using WaterMeterManager.Application.Meters.Queries.GetMeters;
using WaterMeterManager.Domain.Entities;
using WaterMeterReadingValueManager.Application.MeterReadingValues.Queries.GetMeterReadingValues;
using System.Linq;

namespace WaterMeterManager.WebUI.Pages
{
    public class IndexModel : PageModelWithMediator
    {
        public List<Building> Buildings { get; set; }
        public List<Apartment> Apartments { get; set; }
        public List<Meter> Meters { get; set; }
        public List<MeterReadingValue> MeterReadingValues { get; set; }

        public IndexModel()
        {
        }

        public async Task OnGetAsync()
        {
            Buildings = await Mediator.Send(new GetBuildingsListQuery());
            Apartments = await Mediator.Send(new GetApartmentsListQuery());
            Meters = await Mediator.Send(new GetMetersListQuery());
            MeterReadingValues = await Mediator.Send(new GetMeterReadingValuesListQuery());
        }
    }
}