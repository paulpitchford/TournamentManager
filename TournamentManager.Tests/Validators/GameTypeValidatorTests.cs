using FluentValidation.TestHelper;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Validators;

namespace TournamentManager.Tests.Validators
{
    public class GameTypeValidatorTests
    {
        private GameTypeValidator validator;

        public GameTypeValidatorTests()
        {
            validator = new GameTypeValidator();
        }

        [Fact]
        public void ShouldHaveErrorWhenGameTypeNameIsNull()
        {
            // Arrange
            GameType gameType = new GameType { };

            // Act
            var result = validator.TestValidate(gameType);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.GameTypeName);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenGameTypeNameIsSpecified()
        {
            // Arrange
            GameType gameType = new GameType { GameTypeName = "A New Game Type" };

            // Act
            var result = validator.TestValidate(gameType);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.GameTypeName);
        }

        [Fact]
        public void ShouldHaveErrorWhenGameTypeNameIsGreaterThan50Characters()
        {
            // Arrange
            GameType gameType = new GameType { GameTypeName = "p".PadLeft(51, 'p') };

            // Act
            var result = validator.TestValidate(gameType);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.GameTypeName);
        }
    }
}
