using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterManager.Application.Apartments.Queries.GetApartments
{
    public class GetApartmentsListQuery : IRequest<List<Apartment>>
    {
             }

    public class GetApartmentsListQueryHandler : IRequestHandler<GetApartmentsListQuery, List<Apartment>>
    {
        private readonly IApplicationDbContext _context;

        public GetApartmentsListQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Apartment>> Handle(GetApartmentsListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Apartments
                .OrderBy(x => x.BuildingId).ThenBy(x => x.Number)
                .ToListAsync();
        }
    }
}