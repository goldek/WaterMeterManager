using FluentValidation;

namespace WaterMeterManager.Application.Buildings.Commands.CreateBuilding
{
    public class CreateBuildingCommandValidator : AbstractValidator<CreateBuildingCommand>
    {
        public CreateBuildingCommandValidator()
        {
            RuleFor(v => v.Number)
                .MinimumLength(1)
                .NotEmpty();
        }
    }
}