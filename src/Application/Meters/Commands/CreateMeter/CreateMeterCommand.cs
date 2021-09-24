using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;
using WaterMeterManager.Domain.Enums;

namespace WaterMeterManager.Application.Meters.Commands.CreateMeter
{
    public class CreateMeterCommand : IRequest<int>
    {
        public int ApartmentId { get; set; }
        public string SerialNumber { get; set; }
        public MeterType Type { get; set; }
    }

    public class CreateMeterCommandHandler : IRequestHandler<CreateMeterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateMeterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateMeterCommand request, CancellationToken cancellationToken)
        {
            var entity = new Meter
            {
                ApartmentId = request.ApartmentId,
                SerialNumber = request.SerialNumber,
                Type = request.Type
            };

            _context.Meters.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.MeterId;
        }
    }
}