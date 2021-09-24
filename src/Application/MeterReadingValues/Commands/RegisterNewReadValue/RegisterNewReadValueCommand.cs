using Application.Common.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterReadingValueManager.Application.MeterReadingValues.Commands.RegisterNewReadValue
{
    public class RegisterNewReadValueCommand : IRequest<int>
    {
        public int MeterId { get; set; }
        public int ReadValue { get; set; }
        public DateTime ReadingDate { get; set; }
    }

    public class CreateMeterReadingValueCommandHandler : IRequestHandler<RegisterNewReadValueCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateMeterReadingValueCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RegisterNewReadValueCommand request, CancellationToken cancellationToken)
        {
            var meter = await _context.Meters.FindAsync(request.MeterId);
            if (meter == null)
            {
                throw new NotFoundException(nameof(Meter), request.MeterId);
            }

            var entity = new MeterReadingValue
            {
                MeterId = request.MeterId,
                ReadValue = request.ReadValue,
                ReadingDate = request.ReadingDate
            };

            meter.LastReadingValue = request.ReadValue;

            _context.MeterReadingValues.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.MeterReadingValueId;
        }
    }
}