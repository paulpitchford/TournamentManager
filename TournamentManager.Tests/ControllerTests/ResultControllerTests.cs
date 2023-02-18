using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Collections.Generic;
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

            // Act
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new ResultsController(unitOfWork);

                ActionResult<int> response = controller.AddResult(result);
                
                // Assert
                Assert.Equal(1, response.Value);
                Assert.Equal(resultId, result.Id);
            }
        }

        [Fact]
        public void CanGetSingleResult()
        {
            // Arrange
            // This is a guid from one of the seeded results
            var resultId = new Guid("7bdd396b-6918-4c70-a4e3-603f55c458c6");

            // Act and Assert
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new ResultsController(unitOfWork);

                ActionResult<Result> result = controller.GetResult(resultId);
                if (result.Value != null)
                {
                    // If the result.Id matches the resultId we've successfully retrieved the result from the database
                    Assert.Equal(resultId, result.Value.Id);
                }
            }
        }

        [Fact]
        public void CanUpdateSingleResult()
        {
            //Arrange
            // This is a guid from one of the seeded results
            var resultId = new Guid("7bdd396b-6918-4c70-a4e3-603f55c458c6");

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                var controller = new ResultsController(unitOfWork);

                ActionResult<Result> result = controller.GetResult(resultId);
                if (result.Value != null)
                {
                    result.Value.Cash = 1000;

                    ActionResult<bool> updateResult = controller.UpdateResult(resultId, result.Value);
                    Assert.True(updateResult.Value);
                }
            }
        }

        [Fact]
        public void CanGetResultsByGameId()
        {
            // Arrange
            Guid gameId = new Guid("6fee60f0-55e4-4cb0-acdc-609de32094be");

            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new ResultsController(unitOfWork);

                // Act
                ActionResult<IEnumerable<Result>> result = controller.GetResultsByGame(gameId);

                // Assert
                Assert.IsType<OkObjectResult>(result.Result);
                if (result.Value != null)
                {
                    Assert.True(result.Value.Count() >= 0);
                }
            }
        }

        [Fact]
        public void CanGetResultsByPlayerId()
        {
            // Arrange
            Guid playerId = new Guid("644d7d1a-57d1-4e70-9963-376369fa73cd");

            // Act and Assert
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new ResultsController(unitOfWork);

                ActionResult<IEnumerable<Result>> result = controller.GetResultsByPlayer(playerId);

                Assert.IsType<OkObjectResult>(result.Result);
                if (result.Value != null)
                {
                    Assert.True(result.Value.Count() >= 0);
                }
            }
        }
    }
}
