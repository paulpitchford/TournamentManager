using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.RepositoryTests
{
    public class VenueRepositoryTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public VenueRepositoryTests(TestDatabaseFixture fixture)
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

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                unitOfWork.Venues.Add(venue);
                response = unitOfWork.Save();
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

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                venue = unitOfWork.Venues.GetById(venueId);

                // If the venue.Id matches the venueId we've successfully retrieved the venue from the database
                Assert.Equal(venueId, venue.Id);
            }
        }

        [Fact]
        public void CanUpdateSingleVenue()
        {
            // Arrange
            // This is a guid from one of the seeded venues
            var venueId = new Guid("cb29fe0d-e42c-4a8a-9ab9-839caeb9d4ea");
            Venue? venue;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                venue = unitOfWork.Venues.GetById(venueId);

                venue.WebAddress = "https://www.somewebsite.com";

                // If the udpdate is successful the unit of work save method will return 1 to indicate 1 record was saved
                Assert.Equal(1, unitOfWork.Save());
            }
        }
    }
}
