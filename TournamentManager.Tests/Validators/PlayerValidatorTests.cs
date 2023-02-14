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
    public class PlayerValidatorTests
    {
        private PlayerValidator validator;

        public PlayerValidatorTests()
        {
            // Arrange
            validator = new PlayerValidator();
        }

        [Fact]
        public void ShouldHaveErrorWhenFirstNameIsNull()
        {
            // Arrange
            Player player = new Player { };

            // Act
            var result = validator.TestValidate(player);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.FirstName);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenFirstNameIsSpecified()
        {
            // Arrange
            Player player = new Player { FirstName = "Paul" };

            // Act
            var result = validator.TestValidate(player);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.FirstName);
        }

        [Fact]
        public void ShouldHaveErrorWhenLastNameIsNull()
        {
            // Arrange
            Player player = new Player { };

            // Act
            var result = validator.TestValidate(player);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.LastName);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenLastNameIsSpecified()
        {
            // Arrange
            Player player = new Player { LastName = "Pitchford" };

            // Act
            var result = validator.TestValidate(player);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.LastName);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenTournamentDirectorIdIsSpecified()
        {
            // Arrange
            Player player = new Player { TournamentDirectorId = "0bd6aac9-ad90-4fdb-9725-ae363f0d9171" };

            // Act
            var result = validator.TestValidate(player);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.TournamentDirectorId);
        }

        [Fact]
        public void ShouldHaveErrorWhenTournamentDirectorIdIsIncorrectFormat()
        {
            // Arrange
            Player player = new Player { TournamentDirectorId = "Invlaid string for TD_Id" };

            // Act
            var result = validator.TestValidate(player);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.TournamentDirectorId);
        }
    }
}
