using Application.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace Application.Buildings.Commands.UpdateBuilding
{
    public class UpdateBuildingDetailsCommand : IRequest
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }

    public class UpdateBuildingDetailsCommandHandler : IRequestHandler<UpdateBuildingDetailsCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateBuildingDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBuildingDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Buildings.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Building), request.Id);
            }

            entity.City = request.City;
            entity.Street = request.Street;
            entity.Number = request.Number;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}