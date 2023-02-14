using TournamentManager.API.Controllers;
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.ControllerTests
{
    public class PlayerTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public PlayerTests(TestDatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CanAddPlayer()
        {
            // Arrange
            var playerId = Guid.NewGuid();
            var tournameDirectorId = Guid.NewGuid().ToString();
            var player = new Player { Id = playerId, FirstName = "First", LastName = "Last", TournamentDirectorId = tournameDirectorId };
            int response = 0;

            // Act
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new PlayersController(unitOfWork);

                response = controller.AddPlayer(player);
            }

            // Assert
            Assert.Equal(1, response);
            Assert.Equal(playerId, player.Id);
            Assert.Equal(tournameDirectorId, player.TournamentDirectorId);
        }

        [Fact]
        public void CanGetSinglePlayer()
        {
            // Arrange
            // This is a guid from one of the seeded players
            var playerId = new Guid("644d7d1a-57d1-4e70-9963-376369fa73cd");
            Player? player;

            // Act and Assert
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new PlayersController(unitOfWork);

                player = controller.GetPlayer(playerId);

                // If the player.Id matches the playerId we've successfully retrieved the player from the database
                Assert.Equal(playerId, player.Id);
            }
        }

        [Fact]
        public void CanUpdateSinglePlayer()
        {
            // Arrange
            // This is a guid from one of the seeded players
            var playerId = new Guid("644d7d1a-57d1-4e70-9963-376369fa73cd");
            Player? player = null;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                var controller = new PlayersController(unitOfWork);

                player = controller.GetPlayer(playerId);
                player.LastName = "LastName";

                // If the udpdate is successful the unit of work save method will return 1 to indicate 1 record was saved
                Assert.True(controller.UpdatePlayer(playerId, player));
            }
        }
    }
}
