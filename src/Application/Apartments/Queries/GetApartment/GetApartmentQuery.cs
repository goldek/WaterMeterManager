using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace Application.Apartments.Queries.GetApartment
{
    public class GetApartmentQuery : IRequest<Apartment>
    {
        public int Id { get; set; }
    }

    public class GetApartmentQueryHandler : IRequestHandler<GetApartmentQuery, Apartment>
    {
        private readonly IApplicationDbContext _context;

        public GetApartmentQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Apartment> Handle(GetApartmentQuery request, CancellationToken cancellationToken)
        {
            return await _context.Apartments
                         .Where(x => x.ApartmentId == request.Id)
                         .Include(a => a.Meters)
                         .FirstOrDefaultAsync();
        }
    }
}