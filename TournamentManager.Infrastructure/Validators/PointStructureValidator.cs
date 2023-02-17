using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Validators
{
    public class PointStructureValidator : AbstractValidator<PointStructure>
    {
        public PointStructureValidator()
        {
            RuleFor(ps => ps.PointStructureDescription).NotEmpty().WithMessage("Please enter a point structure description").MaximumLength(50).WithMessage("The maximum character length is 50");
            RuleFor(ps => ps.DefaultPoints).NotEmpty().WithMessage("Please select the default number of points for all places");
        }
    }
}
