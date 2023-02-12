using FluentValidation;
using TournamentManager.Infrastructure.Entities;

namespace PokerTournament.Client.Validators
{
    public class SeasonValidator : AbstractValidator<Season>
    {
        public SeasonValidator()
        {
            RuleFor(s => s.SeasonName).NotEmpty().WithMessage("Please enter a season name");
            RuleFor(s => s.StartDate).NotEmpty().GreaterThan(DateTime.MinValue).WithMessage("Please select a valid season start date");
        }
    }
}
