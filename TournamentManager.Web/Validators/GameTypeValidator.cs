using FluentValidation;
using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Web.Validators
{
    public class GameTypeValidator : AbstractValidator<GameType>
    {
        public GameTypeValidator()
        {
            RuleFor(gt => gt.GameTypeName).NotEmpty().WithMessage("Please enter a game type name");
        }
    }
}
