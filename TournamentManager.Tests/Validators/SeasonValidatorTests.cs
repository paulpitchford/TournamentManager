using FluentValidation.TestHelper;
using PokerTournament.Infrastructure.Validators;
using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Tests.Validators
{
    public class SeasonValidatorTests
    {
        private SeasonValidator validator;

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
        public void ShouldNotHaveErrorWhenSeasonIsSpecified()
        {
            // Arrange
            Season season = new Season { SeasonName = "A New Season" };

            // Act
            var result = validator.TestValidate(season);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.SeasonName);
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
        public void ShouldNotHaveErrorWhenStartDateSpecified()
        {
            // Arrange
            Season season = new Season { StartDate = DateTime.Today };

            // Act
            var result = validator.TestValidate(season);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.StartDate);
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

        [Fact]
        public void ShouldHaveErrorWhenPointStructureIdIsNull()
        {
            // Arrange
            Season season = new Season { };

            // Act
            var result = validator.TestValidate(season);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.PointStructureId);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenPointStructureIdIsSpecified()
        {
            // Arrange
            Season season = new Season { PointStructureId = new Guid("d9db6444-f33f-4832-befe-46a17ea765cf") };

            // Act
            var result = validator.TestValidate(season);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.PointStructureId);
        }
    }
}
