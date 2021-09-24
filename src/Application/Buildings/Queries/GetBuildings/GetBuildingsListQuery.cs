using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterManager.Application.Buildings.Queries.GetBuildings
{
    public class GetBuildingsListQuery : IRequest<List<Building>>
    {
    }

    public class GetBuildingsListQueryHandler : IRequestHandler<GetBuildingsListQuery, List<Building>>
    {
        private readonly IApplicationDbContext _context;

        public GetBuildingsListQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Building>> Handle(GetBuildingsListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Buildings
                .Include(a => a.Apartments)
                .OrderBy(x => x.Number)
                .ToListAsync();
        }
    }
}