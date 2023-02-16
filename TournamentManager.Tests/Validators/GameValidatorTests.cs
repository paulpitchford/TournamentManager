using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Validators;

namespace TournamentManager.Tests.Validators
{
    public class GameValidatorTests
    {
        private GameValidator validator;

        public GameValidatorTests()
        {
            validator = new GameValidator();
        }

        [Fact]
        public void ShouldHaveErrorWhenSeasonIdIsNull()
        {
            // Arrange
            Game game = new Game { };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldHaveValidationErrorFor(g => g.SeasonId);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenSeasonIdIsSpecified()
        {
            // Arrange
            Game game = new Game { SeasonId = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e") };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.SeasonId);
        }

        [Fact]
        public void ShouldHaveErrorWhenGameTypeIdIsNull()
        {
            // Arrange
            Game game = new Game { };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldHaveValidationErrorFor(g => g.GameTypeId);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenGameTypeIdIsSpecified()
        {
            // Arrange
            Game game = new Game { GameTypeId = new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0") };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.GameTypeId);
        }

        [Fact]
        public void ShouldHaveErrorWhenVenueIdIsNull()
        {
            // Arrange
            Game game = new Game { };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldHaveValidationErrorFor(g => g.VenueId);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenVenueIsSpecified()
        {
            // Arrange
            Game game = new Game { VenueId = new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d") };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.VenueId);
        }

        [Fact]
        public void ShouldHaveErrorWhenGameTitleIsNull()
        {
            // Arrange
            Game game = new Game { };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldHaveValidationErrorFor(g => g.GameTitle);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenGameTitleIsSpecified()
        {
            // Arrange
            Game game = new Game { GameTitle = "This is a game title" };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.GameTitle);
        }

        [Fact]
        public void ShouldHaveErrorWhenGameTitleIsGreaterThan50Characters()
        {
            // Arrange
            Game game = new Game { GameTitle = "p".PadLeft(51, 'p') };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.GameTitle);
        }

        [Fact]
        public void ShouldHaveErrorWhenGameDateIsNull()
        {
            // Arrange
            Game game = new Game { };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.GameDateTime);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenGameDateSpecified()
        {
            // Arrange
            Game game = new Game { GameDateTime = DateTime.Today };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.GameDateTime);
        }

        [Fact]
        public void ShouldHaveErrorWhenGameDateIsMin()
        {
            // Arrange
            Game game = new Game { GameDateTime = DateTime.MinValue };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.GameDateTime);
        }

        [Fact]
        public void ShouldHaveErrorWhenGameDetailsIsNull()
        {
            // Arrange
            Game game = new Game { };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldHaveValidationErrorFor(g => g.GameDetails);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenGameDetailsIsSpecified()
        {
            // Arrange
            Game game = new Game { GameDetails = "This is some game details" };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.GameDetails);
        }

        [Fact]
        public void ShouldHaveErrorWhenGameDetailsIsGreaterThan50Characters()
        {
            // Arrange
            Game game = new Game { GameDetails = "p".PadLeft(256, 'p') };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.GameTitle);
        }

        [Fact]
        public void ShouldHaveErrorWhenBuyInIsNull()
        {
            // Arrange
            Game game = new Game { };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldHaveValidationErrorFor(g => g.Buyin);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenBuyInIsSpecified()
        {
            // Arrange
            Game game = new Game { Buyin = 35 };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.Buyin);
        }

        [Fact]
        public void ShouldHaveErrorWhenFeeIsNull()
        {
            // Arrange
            Game game = new Game { };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldHaveValidationErrorFor(g => g.Fee);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenFeeIsSpecified()
        {
            // Arrange
            Game game = new Game { Fee = 5 };

            // Act
            var result = validator.TestValidate(game);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.Fee);
        }
    }
}
