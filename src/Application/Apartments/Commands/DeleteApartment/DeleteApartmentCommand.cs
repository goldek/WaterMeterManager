using Application.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace Application.Apartments.Commands.DeleteApartment
{
    public class DeleteApartmentCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteApartmentItemCommandHandler : IRequestHandler<DeleteApartmentCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteApartmentItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteApartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Apartments.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Apartment), request.Id);
            }

            _context.Apartments.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}