using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterReadingValueManager.Application.MeterReadingValues.Queries.GetMeterReadingValues
{
    public class GetMeterReadingValuesListQuery : IRequest<List<MeterReadingValue>>
    {
    }

    public class GetMeterReadingValuesListQueryHandler : IRequestHandler<GetMeterReadingValuesListQuery, List<MeterReadingValue>>
    {
        private readonly IApplicationDbContext _context;

        public GetMeterReadingValuesListQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MeterReadingValue>> Handle(GetMeterReadingValuesListQuery request, CancellationToken cancellationToken)
        {
            return await _context.MeterReadingValues
                .OrderBy(x => x.ReadingDate)
                .ToListAsync();
        }
    }
}