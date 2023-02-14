using TournamentManager.API.Controllers;
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.ControllerTests
{
    public class VenueControllerTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public VenueControllerTests(TestDatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CanAddVenue()
        {
            // Arrange
            var venueId = Guid.NewGuid();
            var venueName = Guid.NewGuid().ToString();
            var venue = new Venue { Id = venueId, VenueName = venueName, Address = "Street", Town = "Town", County = "County", PostCode = "Post Code" };
            int response = 0;

            // Act
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new VenuesController(unitOfWork);

                response = controller.AddVenue(venue);
            }

            // Assert
            Assert.Equal(1, response);
            Assert.Equal(venueId, venue.Id);
            Assert.Equal(venueName, venue.VenueName);
        }

        [Fact]
        public void CanGetSingleVenue()
        {
            // Arrange
            // This is a guid from one of the seeded venues
            var venueId = new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d");
            Venue? venue;

            // Act and Assert
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new VenuesController(unitOfWork);

                venue = controller.GetVenue(venueId);

                // If the venue.Id matches the venueId we've successfully retrieved the venue from the database
                Assert.Equal(venueId, venue.Id);
            }
        }

        [Fact]
        public void CanUpdateSingleVenue()
        {
            // Arrange
            // This is a guid from one of the seeded venues
            var venueId = new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d");
            Venue? venue = null;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                var controller = new VenuesController(unitOfWork);

                venue = controller.GetVenue(venueId);
                venue.WebAddress = "https://www.somewebsite.com";

                // If the udpdate is successful the unit of work save method will return 1 to indicate 1 record was saved
                Assert.True(controller.UpdateVenue(venueId, venue));
            }
        }
    }
}
