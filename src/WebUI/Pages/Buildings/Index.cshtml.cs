using System.Collections.Generic;
using System.Threading.Tasks;
using WaterMeterManager.Application.Buildings.Queries.GetBuildings;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterManager.WebUI.Pages.Buildings
{
    public class IndexModel : PageModelWithMediator
    {
        public List<Building> Buildings { get; set; }

        public IndexModel()
        {
        }

        public async Task OnGetAsync()
        {
            Buildings = await Mediator.Send(new GetBuildingsListQuery());
        }
    }
}