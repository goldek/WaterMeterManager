using Application.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace Application.Meters.Commands.DeleteMeter
{
    public class DeleteMeterCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteMeterItemCommandHandler : IRequestHandler<DeleteMeterCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMeterItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMeterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Meters.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Meter), request.Id);
            }

            _context.Meters.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}