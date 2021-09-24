using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterManager.Application.Apartments.Commands.CreateApartment
{
    public class CreateApartmentCommand : IRequest<int>
    {
        public int BuildingId { get; set; }
        public string Number { get; set; }
        public double Area { get; set; }
    }

    public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateApartmentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Apartment
            {
                BuildingId = request.BuildingId,
                Number = request.Number,
                Area = request.Area
            };

            _context.Apartments.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.ApartmentId;
        }
    }
}