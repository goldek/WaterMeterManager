using Application.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace Application.Buildings.Commands.DeleteBuilding
{
    public class DeleteBuildingCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteBuildingItemCommandHandler : IRequestHandler<DeleteBuildingCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteBuildingItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Buildings.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Building), request.Id);
            }

            _context.Buildings.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}