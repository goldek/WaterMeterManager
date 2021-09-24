using Application.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace Application.Meters.Commands.UpdateMeter
{
    public class UpdateMeterDetailsCommand : IRequest
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
    }

    public class UpdateMeterDetailsCommandHandler : IRequestHandler<UpdateMeterDetailsCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMeterDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMeterDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Meters.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Meter), request.Id);
            }

            entity.SerialNumber = request.SerialNumber;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}