using FluentValidation;
using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Validators
{
    public class GameTypeValidator : AbstractValidator<GameType>
    {
        public GameTypeValidator()
        {
            RuleFor(gt => gt.GameTypeName).NotEmpty().WithMessage("Please enter a game type name").MaximumLength(50).WithMessage("The maximum character length is 50");
        }
    }
}
