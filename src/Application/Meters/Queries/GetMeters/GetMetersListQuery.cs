using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterManager.Application.Meters.Queries.GetMeters
{
    public class GetMetersListQuery : IRequest<List<Meter>>
    {
    }

    public class GetMetersListQueryHandler : IRequestHandler<GetMetersListQuery, List<Meter>>
    {
        private readonly IApplicationDbContext _context;

        public GetMetersListQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Meter>> Handle(GetMetersListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Meters
                .OrderBy(x => x.SerialNumber)
                .ToListAsync();
        }
    }
}