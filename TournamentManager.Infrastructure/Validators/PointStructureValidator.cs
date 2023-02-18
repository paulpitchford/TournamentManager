using FluentValidation;
using System.Reflection;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.Infrastructure.Validators
{
    public class PointStructureValidator : AbstractValidator<PointStructure>
    {
        private readonly IPoints _points;
        public PointStructureValidator(IPoints points)
        {
            _points = points;

            RuleFor(ps => ps.PointStructureDescription).NotEmpty().WithMessage("Please enter a point structure description").MaximumLength(50).WithMessage("The maximum character length is 50");
            RuleFor(ps => ps.DefaultPoints).NotEmpty().WithMessage("Please select the default number of points for all places");

            //This checks the points positions run 1..10 without any missing gaps. E.g. 1..3 - 5..10.In this instance 4 is missing.The validation will fail in this instance.
            RuleFor(ps => ps.PointPositions).Must(pp => pp.Max(p => p.Position) + 1 == _points.NextPosition(pp.Select(p => p.Position).ToList())).WithMessage("The list of positions does not run equal. Pleas ensure they run equal e.g. 1-10.");
        }
    }
}
