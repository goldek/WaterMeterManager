using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace Application.Buildings.Queries.GetBuilding
{
    public class GetBuildingQuery : IRequest<Building>
    {
        public int Id { get; set; }
    }

    public class GetBuildingQueryHandler : IRequestHandler<GetBuildingQuery, Building>
    {
        private readonly IApplicationDbContext _context;

        public GetBuildingQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Building> Handle(GetBuildingQuery request, CancellationToken cancellationToken)
        {
            return await _context.Buildings
                         .Where(x => x.BuildingId == request.Id)
                         .Include(b => b.Apartments)
                         .FirstOrDefaultAsync();
        }
    }
}