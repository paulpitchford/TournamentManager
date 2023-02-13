using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.RepositoryTests
{
    public class VenueTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public VenueTests(TestDatabaseFixture fixture)
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

        [Fact]
        public void CannotAddTwoVenuesWithSameName()
        {
            // Arrange
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                // Make up a random venue name
                string venueName = Guid.NewGuid().ToString();
                unitOfWork.Venues.Add(new Venue { Id = Guid.NewGuid(), VenueName = venueName, Address = "Street", Town = "Town", County = "County", PostCode = "Post Code" });
                unitOfWork.Save();

                // Act and Assert
                var secondVenue = new Venue { Id = Guid.NewGuid(), VenueName = venueName, Address = "Street", Town = "Town", County = "County", PostCode = "Post Code" };
                unitOfWork.Venues.Add(secondVenue);
                var exception = Assert.Throws<DbUpdateException>(() => unitOfWork.Save());
                var sqlException = exception.InnerException as SqlException;

                if (sqlException != null)
                {
                    // If we get a sqlException of 2601 that means that the insert failed due to the constraint which is what this test is ensuring
                    Assert.Equal(2601, sqlException.Number);
                }
            }
        }
    }
}
