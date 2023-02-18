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
    public class PointStructureValidatorTests
    {
        private PointStructureValidator validator;

        public PointStructureValidatorTests()
        {
            validator = new PointStructureValidator();
        }

        [Fact]
        public void ShouldHaveErrorWhenPointStructureDescriptionIsNull()
        {
            // Arrange
            PointStructure pointStructure = new PointStructure { };

            // Act
            var result = validator.TestValidate(pointStructure);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.PointStructureDescription);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenSeasonIsSpecified()
        {
            // Arrange
            PointStructure pointStructure = new PointStructure { PointStructureDescription = "Test Description" };

            // Act
            var result = validator.TestValidate(pointStructure);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.PointStructureDescription);
        }

        [Fact]
        public void ShouldHaveErrorWhenPointStructureDefaultPointsIsNull()
        {
            // Arrange
            PointStructure pointStructure = new PointStructure { };

            // Act
            var result = validator.TestValidate(pointStructure);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.DefaultPoints);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenDefaultPointsIsSpecified()
        {
            // Arrange
            PointStructure pointStructure = new PointStructure { DefaultPoints = 15 };

            // Act
            var result = validator.TestValidate(pointStructure);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.DefaultPoints);
        }
    }
}
