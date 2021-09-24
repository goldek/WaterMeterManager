using Application.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WaterMeterManager.Application.Common.Interfaces;
using WaterMeterManager.Domain.Entities;

namespace Application.Apartments.Commands.UpdateApartment
{
    public class UpdateApartmentDetailsCommand : IRequest
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public double Area { get; set; }
    }

    public class UpdateApartmentDetailsCommandHandler : IRequestHandler<UpdateApartmentDetailsCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateApartmentDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateApartmentDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Apartments.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Apartment), request.Id);
            }

            entity.Number = request.Number;
            entity.Area = request.Area;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}