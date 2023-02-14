using FluentValidation;
using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Validators
{
    public class PlayerValidator : AbstractValidator<Player>
    {
        public PlayerValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("Please enter a first name").MaximumLength(50).WithMessage("The maximum character length is 50");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Please enter a last name").MaximumLength(50).WithMessage("The maximum character length is 50");
            // Checks the string if entered to check if it looks like a real GUID
            RuleFor(p => p.TournamentDirectorId).Must(x => Guid.TryParse(x, out Guid _)).When(p => !string.IsNullOrEmpty(p .TournamentDirectorId)).WithMessage("Invalid TournamentDirector Id format.");
        }
    }
}
