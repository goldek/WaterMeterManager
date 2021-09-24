using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace Application.Meters.Queries.GetMeter
{
    public class GetMeterQuery : IRequest<Meter>
    {
        public int Id { get; set; }
    }

    public class GetMeterQueryHandler : IRequestHandler<GetMeterQuery, Meter>
    {
        private readonly IApplicationDbContext _context;

        public GetMeterQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Meter> Handle(GetMeterQuery request, CancellationToken cancellationToken)
        {
            return await _context.Meters
                         .Where(x => x.MeterId == request.Id)
                         .FirstOrDefaultAsync();
        }
    }
}