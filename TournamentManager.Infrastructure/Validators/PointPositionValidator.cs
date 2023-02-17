using FluentValidation;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Enums;

namespace TournamentManager.Infrastructure.Validators
{
    public class PointPositionValidator : AbstractValidator<PointPosition>
    {
        public PointPositionValidator()
        {
            RuleFor(pp => pp.Position).NotEmpty().WithMessage("Please enter a finishing position");
            RuleFor(pp => pp.Points).NotEmpty().WithMessage("Please enter a points value");
            RuleFor(pp => pp.MultiplierType).IsInEnum().WithMessage("Please choose a multiplier type");
            RuleFor(pp => pp.MultiplierValue).NotEmpty().WithMessage("Please enter a multiplier value");

            RuleFor(pp => pp.MultiplierValue).GreaterThanOrEqualTo(1).When(pp => pp.MultiplierType == PointPositionMultiplierType.MultiplierValue);
        }
    }
}
