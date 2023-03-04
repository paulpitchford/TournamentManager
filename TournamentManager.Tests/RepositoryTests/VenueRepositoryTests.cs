using EntityFramework.Exceptions.Common;
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

        [Fact]
        public void CanRemoveVenue()
        {
            // Arrange
            // This is a guid from one of the seeded venues
            Venue? venue = new Venue { VenueName = "Delete Test Venue", Address = "High Pavement", Town = "Sutton in Ashfield", County = "Nottinghamshire", PostCode = "NG17 4BA" };
            int result = 0;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);

                if (venue != null)
                {
                    unitOfWork.Venues.Add(venue);
                    unitOfWork.Save();

                    unitOfWork.Venues.Remove(venue);
                    result = unitOfWork.Save();
                }

                // If the result is greater than zero, we now the data has been affected which means it's been deleted
                Assert.True(result > 0);
            }
        }

        [Fact]
        public void CannotRemoveVenueIfTheVenueHasGames()
        {
            // Arrange
            Guid venueId = new Guid("6ad5b41c-c782-4aad-b55c-5249f63f07b3");
            Venue? venue = new Venue { Id = venueId, VenueName = "Delete Test Venue", Address = "High Pavement", Town = "Sutton in Ashfield", County = "Nottinghamshire", PostCode = "NG17 4BA" };
            Game? game = new Game { Id = Guid.NewGuid(), SeasonId = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"), Buyin = 35, Fee = 5, GameDateTime = DateTime.Now.AddDays(7), GameDetails = "Test Game", GameTitle = "Test Game", GameTypeId = new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"), VenueId = new Guid("6ad5b41c-c782-4aad-b55c-5249f63f07b3"), PublishResults = false };
            venue.Games.Add(game);

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);

                if (venue != null)
                {
                    unitOfWork.Venues.Add(venue);
                    unitOfWork.Save();

                    unitOfWork.Venues.Remove(venue);

                    var exception = Assert.Throws<CannotInsertNullException>(() => unitOfWork.Save());
                    var sqlException = exception.InnerException as SqlException;

                    if (sqlException != null)
                    {
                        // If we get a sqlException of 515 that means that the remove failed because of the games that exist on the entity
                        Assert.Equal(515, sqlException.Number);
                    }
                }
            }
        }
    }
}
