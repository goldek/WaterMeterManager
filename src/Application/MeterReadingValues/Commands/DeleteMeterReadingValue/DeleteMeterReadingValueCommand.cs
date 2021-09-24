using Application.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace Application.MeterReadingValues.Commands.DeleteMeterReadingValue
{
    public class DeleteMeterReadingValueCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteMeterReadingValueItemCommandHandler : IRequestHandler<DeleteMeterReadingValueCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMeterReadingValueItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMeterReadingValueCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.MeterReadingValues.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(MeterReadingValue), request.Id);
            }

            _context.MeterReadingValues.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}