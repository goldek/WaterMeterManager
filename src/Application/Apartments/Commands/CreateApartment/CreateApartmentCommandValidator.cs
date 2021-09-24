using FluentValidation;

namespace WaterMeterManager.Application.Apartments.Commands.CreateApartment
{
    public class CreateApartmentCommandValidator : AbstractValidator<CreateApartmentCommand>
    {
        public CreateApartmentCommandValidator()
        {
            RuleFor(v => v.Number)
                .MinimumLength(1)
                .NotEmpty();

            RuleFor(v => v.Area)
                .GreaterThan(1);
        }
    }
}