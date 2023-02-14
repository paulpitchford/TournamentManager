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
            // Arrange
            Season season = new Season { };

            // Act
            var result = validator.TestValidate(season);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.SeasonName);
        }

        [Fact]
        public void ShouldHaveErrorWhenSeasonNameIsGreaterThan50Characters()
        {
            // Arrange
            Season season = new Season { SeasonName = "p".PadLeft(51, 'p') };

            // Act
            var result = validator.TestValidate(season);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.SeasonName);
        }

        [Fact]
        public void ShouldHaveErrorWhenStartDateIsNull()
        {
            // Arrange
            Season season = new Season { };

            // Act
            var result = validator.TestValidate(season);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.SeasonName);
        }

        [Fact]
        public void ShouldHaveErrorWhenStartDateIsMin()
        {
            // Arrange
            Season season = new Season { StartDate = DateTime.MinValue };

            // Act
            var result = validator.TestValidate(season);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.SeasonName);
        }
    }
}
