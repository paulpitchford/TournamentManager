using FluentValidation.TestHelper;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Enums;
using TournamentManager.Infrastructure.Interfaces;
using TournamentManager.Infrastructure.Validators;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.Validators
{
    public class PointStructureValidatorTests : IClassFixture<PositionFactoryFixtures>
    {
        private PositionFactoryFixtures _fixture;

        private PointStructureValidator validator;

        public PointStructureValidatorTests(PositionFactoryFixtures fixture)
        {
            _fixture = fixture;
            validator = new PointStructureValidator(_fixture.PositionFactory);
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

        [Fact]
        public void ShouldNotFailIfListOfPositionsRunEqual()
        {
            // A structures children should run equal, e.g. 1..10, not 1..3 - 5..10 (4 missing). This test ensures the rule fails.

            // Arrange
            PointStructure pointStructure = new PointStructure
            {
                Id = Guid.NewGuid(),
                PointStructureDescription = "Test",
                DefaultPoints = 15,
                PointPositions = new List<PointPosition>
                {
                    new PointPosition
                    {
                        Position = 1, Points = 200, MultiplierType = PointPositionMultiplierType.PlayerCount, MultiplierValue = 0
                    },
                    new PointPosition
                    {
                        Position = 2, Points = 150, MultiplierType = PointPositionMultiplierType.PlayerCount, MultiplierValue = 0
                    },
                    // 3 is missing in this example
                    new PointPosition
                    {
                        Position = 3, Points = 100, MultiplierType = PointPositionMultiplierType.PlayerCount, MultiplierValue = 0
                    },
                    new PointPosition
                    {
                        Position = 4, Points = 50, MultiplierType = PointPositionMultiplierType.PlayerCount, MultiplierValue = 0
                    },
                }
            };

            // Act
            var result = validator.TestValidate(pointStructure);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.PointPositions);
        }

        [Fact]
        public void ShouldFailIfListOfPositionsDoesNotRunEqual()
        {
            // A structures children should run equal, e.g. 1..10, not 1..3 - 5..10 (4 missing). This test ensures the rule fails.

            // Arrange
            PointStructure pointStructure = new PointStructure
            {
                Id = Guid.NewGuid(),
                PointStructureDescription = "Test",
                DefaultPoints = 15,
                PointPositions = new List<PointPosition>
                {
                    new PointPosition 
                    {
                        Position = 1, Points = 200, MultiplierType = PointPositionMultiplierType.PlayerCount, MultiplierValue = 0
                    },
                    new PointPosition
                    {
                        Position = 2, Points = 150, MultiplierType = PointPositionMultiplierType.PlayerCount, MultiplierValue = 0
                    },
                    // 3 is missing in this example
                    new PointPosition
                    {
                        Position = 4, Points = 100, MultiplierType = PointPositionMultiplierType.PlayerCount, MultiplierValue = 0
                    },
                    new PointPosition
                    {
                        Position = 5, Points = 50, MultiplierType = PointPositionMultiplierType.PlayerCount, MultiplierValue = 0
                    },
                }
            };

            // Act
            var result = validator.TestValidate(pointStructure);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.PointPositions);
        }
    }
}
