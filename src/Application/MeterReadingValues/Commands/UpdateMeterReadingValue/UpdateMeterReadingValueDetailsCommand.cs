using Application.Common.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace Application.MeterReadingValues.Commands.UpdateMeterReadingValue
{
    public class UpdateMeterReadingValueDetailsCommand : IRequest
    {
        public int Id { get; set; }
        public int ReadValue { get; set; }
        public DateTime ReadingDate { get; set; }
    }

    public class UpdateMeterReadingValueDetailsCommandHandler : IRequestHandler<UpdateMeterReadingValueDetailsCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMeterReadingValueDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMeterReadingValueDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.MeterReadingValues.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(MeterReadingValue), request.Id);
            }

            entity.ReadValue = request.ReadValue;
            entity.ReadingDate = request.ReadingDate;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}