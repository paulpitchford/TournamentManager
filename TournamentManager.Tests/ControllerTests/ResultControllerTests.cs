using TournamentManager.API.Controllers;
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.ControllerTests
{
    public class ResultControllerTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public ResultControllerTests(TestDatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CanAddResult()
        {
            // Arrange
            var resultId = Guid.NewGuid();
            var result = new Result
            {
                Id = resultId,
                GameId = new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be"),
                PlayerId = new Guid("35d039f5-8c42-4764-beda-ae2e563e8c27"),
                Position = 11,
                Cash = 0d,
                Points = 15d
            };
            int response = 0;

            // Act
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new ResultsController(unitOfWork);

                response = controller.AddResult(result);
            }

            // Assert
            Assert.Equal(1, response);
            Assert.Equal(resultId, result.Id);
        }

        [Fact]
        public void CanGetSingleResult()
        {
            // Arrange
            // This is a guid from one of the seeded results
            var resultId = new Guid("7bdd396b-6918-4c70-a4e3-603f55c458c6");
            Result? result;

            // Act and Assert
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new ResultsController(unitOfWork);

                result = controller.GetResult(resultId);

                // If the result.Id matches the resultId we've successfully retrieved the result from the database
                Assert.Equal(resultId, result.Id);
            }
        }

        [Fact]
        public void CanUpdateSingleResult()
        {
            // Arrange
            // This is a guid from one of the seeded results
            var resultId = new Guid("7bdd396b-6918-4c70-a4e3-603f55c458c6");
            Result? result;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                var controller = new ResultsController(unitOfWork);

                result = controller.GetResult(resultId);
                result.Cash = 1000;

                // If the udpdate is successful the unit of work save method will return 1 to indicate 1 record was saved
                Assert.True(controller.UpdateResult(resultId, result));
            }
        }

        [Fact]
        public void CanGetResultsByGameId()
        {
            // Arrange
            List<Result> results = new List<Result>();
            Guid gameId = new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be");
            
            // Act and Assert
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new ResultsController(unitOfWork);

                results = controller.GetResultsByGame(gameId).ToList();

                // If the result.Id matches the resultId we've successfully retrieved the result from the database
                Assert.True(results.Count >= 1);
            }
        }

        [Fact]
        public void CanGetResultsByPlayerId()
        {
            // Arrange
            List<Result> results = new List<Result>();
            Guid playerId = new Guid("644d7d1a-57d1-4e70-9963-376369fa73cd");

            // Act and Assert
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new ResultsController(unitOfWork);

                results = controller.GetResultsByPlayer(playerId).ToList();

                // If the result.Id matches the resultId we've successfully retrieved the result from the database
                Assert.True(results.Count >= 1);
            }
        }
    }
}
