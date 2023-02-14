using FluentValidation;
using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Validators
{
    public class VenueValiator : AbstractValidator<Venue>
    {
        public VenueValiator()
        {
            RuleFor(v => v.VenueName).NotEmpty().WithMessage("Please enter a venue name").MaximumLength(50).WithMessage("The maximum character length is 50");
            RuleFor(v => v.Address).NotEmpty().WithMessage("Please enter an address").MaximumLength(255).WithMessage("The maximum character length is 255");
            RuleFor(v => v.Town).NotEmpty().WithMessage("Please enter a town").MaximumLength(50).WithMessage("The maximum character length is 50");
            RuleFor(v => v.County).NotEmpty().WithMessage("Please enter a county").MaximumLength(50).WithMessage("The maximum character length is 50");
            RuleFor(v => v.PostCode).NotEmpty().WithMessage("Please enter a post code").MaximumLength(50).WithMessage("The maximum character length is 50");
            RuleFor(v => v.PhoneNumber).MaximumLength(50).WithMessage("The maximum character length is 50");
            RuleFor(v => v.WebAddress).MaximumLength(255).WithMessage("The maximum character length is 255");
            RuleFor(v => v.FacebookAddress).MaximumLength(255).WithMessage("The maximum character length is 255");
            RuleFor(v => v.ExtraInformation).MaximumLength(255).WithMessage("The maximum character length is 255");
        }
    }
}
