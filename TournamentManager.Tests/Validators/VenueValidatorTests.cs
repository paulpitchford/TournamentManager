using FluentValidation.TestHelper;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Validators;

namespace TournamentManager.Tests.Validators
{
    public class VenueValidatorTests
    {
        private VenueValiator validator;

        public VenueValidatorTests()
        {
            validator = new VenueValiator();
        }

        [Fact]
        public void ShouldHaveErrorWhenVenueNameIsNull()
        {
            // Arrange
            Venue venue = new Venue { };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.VenueName);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenVenueNameIsSpecified()
        {
            // Arrange
            Venue venue = new Venue { VenueName = "Pauls Pub" };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.VenueName);
        }

        [Fact]
        public void ShouldHaveErrorWhenVenueNameIsGreaterThan50Characters()
        {
            // Arrange
            Venue venue = new Venue { VenueName = "p".PadLeft(51, 'p') };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.VenueName);
        }

        [Fact]
        public void ShouldHaveErrorWhenAddressIsNull()
        {
            // Arrange
            Venue venue = new Venue { };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.Address);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenAddressIsSpecified()
        {
            // Arrange
            Venue venue = new Venue { Address = "Some Street" };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.Address);
        }

        [Fact]
        public void ShouldHaveErrorWhenAddressIsGreaterThan255Characters()
        {
            // Arrange
            Venue venue = new Venue { Address = "p".PadLeft(256, 'p') };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.Address);
        }

        [Fact]
        public void ShouldHaveErrorWhenTownIsNull()
        {
            // Arrange
            Venue venue = new Venue { };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.Town);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenTownIsSpecified()
        {
            // Arrange
            Venue venue = new Venue { Town = "Some Town" };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.Town);
        }

        [Fact]
        public void ShouldHaveErrorWhenVenueTownIsGreaterThan50Characters()
        {
            // Arrange
            Venue venue = new Venue { Town = "p".PadLeft(51, 'p') };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.Town);
        }

        [Fact]
        public void ShouldHaveErrorWhenCountyIsNull()
        {
            // Arrange
            Venue venue = new Venue { };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.County);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenCountyIsSpecified()
        {
            // Arrange
            Venue venue = new Venue { County = "County" };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.County);
        }

        [Fact]
        public void ShouldHaveErrorWhenVenueCountyIsGreaterThan50Characters()
        {
            // Arrange
            Venue venue = new Venue { County = "p".PadLeft(51, 'p') };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.County);
        }

        [Fact]
        public void ShouldHaveErrorWhenPostCodeIsNull()
        {
            // Arrange
            Venue venue = new Venue { };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.PostCode);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenPostCodeIsSpecified()
        {
            // Arrange
            Venue venue = new Venue { PostCode = "A Post Code" };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.PostCode);
        }

        [Fact]
        public void ShouldHaveErrorWhenVenuePostCodeIsGreaterThan50Characters()
        {
            // Arrange
            Venue venue = new Venue { PostCode = "p".PadLeft(51, 'p') };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.PostCode);
        }

        [Fact]
        public void ShouldHaveErrorWhenPhoneNumberIsGreaterThan50Characters()
        {
            // Arrange
            Venue venue = new Venue { PhoneNumber = "p".PadLeft(51, 'p') };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.PhoneNumber).When(p => !string.IsNullOrEmpty(p.PropertyName));
        }

        [Fact]
        public void ShouldHaveErrorWhenWebAddressIsGreaterThan255Characters()
        {
            // Arrange
            Venue venue = new Venue { WebAddress = "p".PadLeft(256, 'p') };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.WebAddress);
        }

        [Fact]
        public void ShouldHaveErrorWhenFacebookAddressIsGreaterThan255Characters()
        {
            // Arrange
            Venue venue = new Venue { FacebookAddress = "p".PadLeft(256, 'p') };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.FacebookAddress);
        }

        [Fact]
        public void ShouldHaveErrorWhenExtraInformationIsGreaterThan255Characters()
        {
            // Arrange
            Venue venue = new Venue { ExtraInformation = "p".PadLeft(256, 'p') };

            // Act
            var result = validator.TestValidate(venue);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.ExtraInformation);
        }
    }
}
