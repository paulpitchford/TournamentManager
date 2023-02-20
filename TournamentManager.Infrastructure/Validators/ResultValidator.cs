using FluentValidation;
using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Validators
{
    public class ResultValidator : AbstractValidator<Result>
    {
        public ResultValidator()
        {
            RuleFor(r => r.PlayerId).NotEmpty().WithMessage("Please select a player");
            RuleFor(r => r.Cash).NotNull().WithMessage("Please enter a cash value");

        }
    }
}
