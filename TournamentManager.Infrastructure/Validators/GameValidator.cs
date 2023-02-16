using FluentValidation;
using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Validators
{
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {
            RuleFor(g => g.SeasonId).NotEmpty().WithMessage("Please select a season");
            RuleFor(g => g.GameTypeId).NotEmpty().WithMessage("Please select a game type");
            RuleFor(g => g.VenueId).NotEmpty().WithMessage("Please select a venue");
            RuleFor(s => s.GameTitle).NotEmpty().WithMessage("Please enter a game title").MaximumLength(50).WithMessage("The maximum character length is 50");
            RuleFor(s => s.GameDateTime).NotEmpty().GreaterThan(DateTime.MinValue).WithMessage("Please select a valid season game date");
            RuleFor(s => s.GameDetails).NotEmpty().WithMessage("Please enter the game details").MaximumLength(255).WithMessage("The maximum character length is 255");
            RuleFor(s => s.Buyin).NotEmpty().WithMessage("Please enter a buy-in");
            RuleFor(s => s.Fee).NotEmpty().WithMessage("Please enter a buy-in");

        }
    }
}
