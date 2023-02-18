using FluentValidation.TestHelper;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Enums;
using TournamentManager.Infrastructure.Validators;

namespace TournamentManager.Tests.Validators
{
    public class PointPositionValidatorTests
    {
        private PointPositionValidator validator;

        public PointPositionValidatorTests()
        {
            validator = new PointPositionValidator();
        }

        [Fact]
        public void ShouldHaveErrorWhenPositionIsNull()
        {
            // Arrange
            PointPosition pointPosition = new PointPosition { };

            // Act
            var result = validator.TestValidate(pointPosition);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.Position);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenPositionIsSpecified()
        {
            // Arrange
            PointPosition pointPosition = new PointPosition { Position = 1 };

            // Act
            var result = validator.TestValidate(pointPosition);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.Position);
        }

        [Fact]
        public void ShouldHaveErrorWhenPointsIsNull()
        {
            // Arrange
            PointPosition pointPosition = new PointPosition { };

            // Act
            var result = validator.TestValidate(pointPosition);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.Points);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenPointsIsSpecified()
        {
            // Arrange
            PointPosition pointPosition = new PointPosition { Points = 100 };

            // Act
            var result = validator.TestValidate(pointPosition);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.Points);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenMultiplierTypeIsSpecified()
        {
            // Arrange
            PointPosition pointPosition = new PointPosition { MultiplierType = PointPositionMultiplierType.PlayerCount };

            // Act
            var result = validator.TestValidate(pointPosition);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.MultiplierType);
        }

        [Fact]
        public void ShouldHaveErrorWhenMultiplierValueIsNull()
        {
            // Arrange
            PointPosition pointPosition = new PointPosition { };

            // Act
            var result = validator.TestValidate(pointPosition);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.MultiplierValue);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenMultiplierValueIsSpecified()
        {
            // Arrange
            PointPosition pointPosition = new PointPosition { MultiplierValue = 10 };

            // Act
            var result = validator.TestValidate(pointPosition);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.MultiplierValue);
        }

        [Fact]
        void ShouldHaveErrorWhenMultiplierTypeEqualsPlayerCountAndMultiplierValueIsZero()
        {
            // Arrange
            PointPosition pointPosition = new PointPosition { MultiplierType = PointPositionMultiplierType.PlayerCount };

            // Act
            var result = validator.TestValidate(pointPosition);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.MultiplierValue);
        }
    }
}
