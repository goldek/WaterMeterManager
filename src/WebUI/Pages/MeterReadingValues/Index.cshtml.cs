using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using WaterMeterManager.Domain.Entities;
using WaterMeterReadingValueManager.Application.MeterReadingValues.Queries.GetMeterReadingValues;

namespace WaterMeterManager.WebUI.Pages.MeterReadingValues
{
    public class ListModel : PageModelWithMediator
    {
        public List<MeterReadingValue> MeterReadingValues { get; set; }

        public async Task OnGetAsync()
        {
            MeterReadingValues = await Mediator.Send(new GetMeterReadingValuesListQuery());
        }
    }
}