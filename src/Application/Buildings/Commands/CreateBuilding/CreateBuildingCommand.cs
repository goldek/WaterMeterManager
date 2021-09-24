using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace WaterMeterManager.Application.Buildings.Commands.CreateBuilding
{
    public class CreateBuildingCommand : IRequest<int>
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }

    public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateBuildingCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            var entity = new Building
            {
                City = request.City,
                Street = request.Street,
                Number = request.Number
            };

            _context.Buildings.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.BuildingId;
        }
    }
}