using FluentValidation.TestHelper;
using PokerTournament.Infrastructure.Validators;
using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Tests.Validators
{
    public class SeasonValidatorTests
    {
        private SeasonValidator validator = default!;

        [Fact]
        public void ShouldHaveErrorWhenSeasonNameIsNull()
        {
            // Arrange 
            validator = new SeasonValidator();

            // Act
            Season season = new Season { };
            var result = validator.TestValidate(season);
            
            // Assert
            result.ShouldHaveValidationErrorFor(p => p.SeasonName);
        }

        [Fact]
        public void ShouldHaveErrorWhenSeasonNameIsGreaterThan50Characters()
        {
            // Arrange 
            validator = new SeasonValidator();

            // Act
            Season season = new Season { SeasonName = "p".PadLeft(51, 'p') };
            var result = validator.TestValidate(season);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.SeasonName);
        }

        [Fact]
        public void ShouldHaveErrorWhenStartDateIsNull()
        {
            // Arrange 
            validator = new SeasonValidator();

            // Act
            Season season = new Season { };
            var result = validator.TestValidate(season);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.SeasonName);
        }

        [Fact]
        public void ShouldHaveErrorWhenStartDateIsMin()
        {
            // Arrange 
            validator = new SeasonValidator();

            // Act
            Season season = new Season { StartDate = DateTime.MinValue };
            var result = validator.TestValidate(season);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.SeasonName);
        }
    }
}
