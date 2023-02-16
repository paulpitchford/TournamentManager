using TournamentManager.API.Controllers;
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.ControllerTests
{
    public class SeasonControllerTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public SeasonControllerTests(TestDatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CanAddSeason()
        {
            // Arrange
            var seasonId = Guid.NewGuid();
            var seasonName = Guid.NewGuid().ToString();
            var season = new Season { Id = seasonId, SeasonName = seasonName, StartDate = DateTime.Today, PointStructureId = new Guid("d9db6444-f33f-4832-befe-46a17ea765cf") };
            int response = 0;

            // Act
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new SeasonsController(unitOfWork);

                response = controller.AddSeason(season);
            }

            // Assert
            Assert.Equal(1, response);
            Assert.Equal(seasonId, season.Id);
            Assert.Equal(seasonName, season.SeasonName);
        }

        [Fact]
        public void CanGetSingleSeason()
        {
            // Arrange
            // This is a guid from one of the seeded seasons
            var seasonId = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e");
            Season? season;

            // Act and Assert
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new SeasonsController(unitOfWork);

                season = controller.GetSeason(seasonId);

                // If the season.Id matches the seasonId we've successfully retrieved the season from the database
                Assert.Equal(seasonId, season.Id);
            }
        }

        [Fact]
        public void CanUpdateSingleSeason()
        {
            // Arrange
            // This is a guid from one of the seeded seasons
            var seasonId = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e");
            Season? season = null;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                var controller = new SeasonsController(unitOfWork);

                season = controller.GetSeason(seasonId);
                season.StartDate = DateTime.Now;

                // If the udpdate is successful the unit of work save method will return 1 to indicate 1 record was saved
                Assert.True(controller.UpdateSeason(seasonId, season));
            }
        }
    }
}
