using FluentValidation;

namespace WaterMeterManager.Application.Meters.Commands.CreateMeter
{
    public class RegisterNewReadValueCommandValidator : AbstractValidator<CreateMeterCommand>
    {
        public RegisterNewReadValueCommandValidator()
        {
            RuleFor(v => v.SerialNumber)
                .MinimumLength(7)
                .MaximumLength(10)
                .NotEmpty();
        }
    }
}