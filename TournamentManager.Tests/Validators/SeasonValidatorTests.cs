using FluentValidation.TestHelper;
using PokerTournament.Infrastructure.Validators;
using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Tests.Validators
{
    public class SeasonValidatorTests
    {
        private SeasonValidator validator = default!;

        public SeasonValidatorTests()
        {
            // Arrange 
            validator = new SeasonValidator();
        }

        [Fact]
        public void ShouldHaveErrorWhenSeasonNameIsNull()
        {
            // Act
            Season season = new Season { };
            var result = validator.TestValidate(season);
            
            // Assert
            result.ShouldHaveValidationErrorFor(p => p.SeasonName);
        }

        [Fact]
        public void ShouldHaveErrorWhenSeasonNameIsGreaterThan50Characters()
        {
            // Act
            Season season = new Season { SeasonName = "p".PadLeft(51, 'p') };
            var result = validator.TestValidate(season);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.SeasonName);
        }

        [Fact]
        public void ShouldHaveErrorWhenStartDateIsNull()
        {
            // Act
            Season season = new Season { };
            var result = validator.TestValidate(season);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.SeasonName);
        }

        [Fact]
        public void ShouldHaveErrorWhenStartDateIsMin()
        {
            // Act
            Season season = new Season { StartDate = DateTime.MinValue };
            var result = validator.TestValidate(season);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.SeasonName);
        }
    }
}
