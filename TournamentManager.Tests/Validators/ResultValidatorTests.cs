using FluentValidation.TestHelper;
using PokerTournament.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Validators;

namespace TournamentManager.Tests.Validators
{
    public class ResultValidatorTests
    {
        private ResultValidator validator;

        public ResultValidatorTests()
        {
            validator = new ResultValidator();
        }

        [Fact]
        public void ShouldHaveErrorWhenPlayerIsNull()
        {
            // Arrange
            Result result = new Result { };

            // Act
            var validationResult = validator.TestValidate(result);

            // Assert
            validationResult.ShouldHaveValidationErrorFor(r => r.PlayerId);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenPlayerIsSpecified()
        {
            // Arrange
            Result result = new Result { PlayerId = new Guid("644d7d1a-57d1-4e70-9963-376369fa73cd") };

            // Act
            var validationResult = validator.TestValidate(result);

            // Assert
            validationResult.ShouldNotHaveValidationErrorFor(p => p.PlayerId);
        }
    }
}
