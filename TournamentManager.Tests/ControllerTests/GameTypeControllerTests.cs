using TournamentManager.API.Controllers;
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.ControllerTests
{
    public class GameTypeControllerTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public GameTypeControllerTests(TestDatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CanAddGameType()
        {
            // Arrange
            var gameTypeId = Guid.NewGuid();
            var gameTypeName = Guid.NewGuid().ToString();
            var gameType = new GameType { Id = gameTypeId, GameTypeName = gameTypeName, AwardPoints = true };
            int response = 0;

            // Act
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new GameTypesController(unitOfWork);

                response = controller.AddGameType(gameType);
            }

            // Assert
            Assert.Equal(1, response);
            Assert.Equal(gameTypeId, gameType.Id);
            Assert.Equal(gameTypeName, gameType.GameTypeName);
        }

        [Fact]
        public void CanGetSingleGameType()
        {
            // Arrange
            // This is a guid from one of the seeded gameTypes
            var gameTypeId = new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0");
            GameType? gameType;

            // Act and Assert
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new GameTypesController(unitOfWork);

                gameType = controller.GetGameType(gameTypeId);

                // If the gameType.Id matches the gameTypeId we've successfully retrieved the gameType from the database
                Assert.Equal(gameTypeId, gameType.Id);
            }
        }

        [Fact]
        public void CanUpdateSingleGameType()
        {
            // Arrange
            // This is a guid from one of the seeded gameTypes
            var gameTypeId = new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0");
            var gameTypeName = Guid.NewGuid().ToString();
            GameType? gameType;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                var controller = new GameTypesController(unitOfWork);

                gameType = controller.GetGameType(gameTypeId);
                gameType.GameTypeName = gameTypeName;

                // If the udpdate is successful the unit of work save method will return 1 to indicate 1 record was saved
                Assert.True(controller.UpdateGameType(gameTypeId, gameType));
            }
        }
    }
}
