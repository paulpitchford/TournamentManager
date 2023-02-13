using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.RepositoryTests
{
    public class ResultTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public ResultTests(TestDatabaseFixture fixture)
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
                GameId = new Guid("c9a29408-0b4e-44a8-8a23-c51ddb8b360a"),
                PlayerId = new Guid("02f03bbe-dcc3-47c6-bc17-a0dc30822f57"),
                Position = 11,
                Cash = 0d,
                Points = 15d
            };

            int response = 0;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                unitOfWork.Results.Add(result);
                response = unitOfWork.Save();
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

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                result = unitOfWork.Results.GetById(resultId);

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
                result = unitOfWork.Results.GetById(resultId);

                result.Cash = 1000d;

                // If the udpdate is successful the unit of work save method will return 1 to indicate 1 record was saved
                Assert.Equal(1, unitOfWork.Save());
            }
        }

        [Fact]
        public void CannotAddAPlayerToTheSameGameResultsTwice()
        {
            // Arrange
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                Guid gameId = new Guid("87450acd-ca09-40c2-883b-aad03402f9dc");
                Guid playerId = new Guid("644d7d1a-57d1-4e70-9963-376369fa73cd");
                unitOfWork.Results.Add(new Result { Id = Guid.NewGuid(), GameId = gameId, PlayerId = playerId, Position = 1, Points = 200, Cash = 200 });
                unitOfWork.Save();

                // Act and Assert
                var secondResult = new Result { Id = Guid.NewGuid(), GameId = gameId, PlayerId = playerId, Position = 2, Points = 175, Cash = 150 };
                unitOfWork.Results.Add(secondResult);
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
