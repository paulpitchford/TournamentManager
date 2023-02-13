using TournamentManager.API.Controllers;
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.ControllerTests
{
    public class GameTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public GameTests(TestDatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CanAddGame()
        {
            // Arrange
            var gameId = Guid.NewGuid();
            var gameTitle = Guid.NewGuid().ToString();
            var game = new Game
            {
                Id = gameId,
                SeasonId = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"),
                GameTypeId = new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"),
                VenueId = new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d"),
                GameTitle = gameTitle,
                GameDateTime = DateTime.Now,
                PublishResults = false,
                GameDetails = "Test Game Details",
                Buyin = 35d,
                Fee = 5d
            };
            int response = 0;

            // Act
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new GamesController(unitOfWork);

                response = controller.AddGame(game);
            }

            // Assert
            Assert.Equal(1, response);
            Assert.Equal(gameId, game.Id);
            Assert.Equal(gameTitle, game.GameTitle);
        }

        [Fact]
        public void CanGetSingleGame()
        {
            // Arrange
            // This is a guid from one of the seeded games
            var gameId = new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be");
            Game? game;

            // Act and Assert
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new GamesController(unitOfWork);

                game = controller.GetGame(gameId);

                // If the game.Id matches the gameId we've successfully retrieved the game from the database
                Assert.Equal(gameId, game.Id);
            }
        }

        [Fact]
        public void CanUpdateSingleGame()
        {
            // Arrange
            // This is a guid from one of the seeded games
            var gameId = new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be");
            var gameTitle = Guid.NewGuid().ToString();
            Game? game;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                var controller = new GamesController(unitOfWork);

                game = controller.GetGame(gameId);
                game.GameTitle = gameTitle;

                // If the udpdate is successful the unit of work save method will return 1 to indicate 1 record was saved
                Assert.True(controller.UpdateGame(gameId, game));
            }
        }

        [Fact]
        public void CanGetGamesBySeasonId()
        {
            // Arrange
            List<Game> games = new List<Game>();
            Guid seasonId = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e");
            
            // Act and Assert
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new GamesController(unitOfWork);

                games = controller.GetGamesBySeason(seasonId).ToList();

                // If the game.Id matches the gameId we've successfully retrieved the game from the database
                Assert.True(games.Count > 1);
            }
        }
    }
}
