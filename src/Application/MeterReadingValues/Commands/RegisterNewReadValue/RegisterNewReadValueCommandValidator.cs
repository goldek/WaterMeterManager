using FluentValidation;
using WaterMeterReadingValueManager.Application.MeterReadingValues.Commands.RegisterNewReadValue;

namespace WaterMeterManager.Application.Meters.Commands.MeterReadingValues.RegisterNewReadValue
{
    public class RegisterNewReadValueCommandValidator : AbstractValidator<RegisterNewReadValueCommand>
    {
        public RegisterNewReadValueCommandValidator()
        {
            RuleFor(v => v.ReadValue)
                .GreaterThan(0)
                .NotEmpty();
        }
    }
}