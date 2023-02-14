using FluentValidation;
using TournamentManager.Infrastructure.Entities;

namespace PokerTournament.Infrastructure.Validators
{
    public class SeasonValidator : AbstractValidator<Season>
    {
        public SeasonValidator()
        {
            RuleFor(s => s.SeasonName).NotEmpty().WithMessage("Please enter a season name").MaximumLength(50).WithMessage("The maximum character length is 50");
            RuleFor(s => s.StartDate).NotEmpty().GreaterThan(DateTime.MinValue).WithMessage("Please select a valid season start date");
        }
    }
}
