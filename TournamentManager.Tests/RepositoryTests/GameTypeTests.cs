using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.RepositoryTests
{
    public class GameTypeTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public GameTypeTests(TestDatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CanAddGameType()
        {
            // Arrange
            var gameTypeId = Guid.NewGuid();
            string gameTypeName = "Test Game Type";
            var gameType = new GameType { Id = gameTypeId, GameTypeName = gameTypeName, AwardPoints = false };


            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                unitOfWork.GameType.Add(gameType);
                unitOfWork.Save();
            }

            // Assert
            Assert.Equal(gameTypeId, gameType.Id);
            Assert.Equal(gameTypeName, gameType.GameTypeName);
        }

        [Fact]
        public void CanGetSingleGameType()
        {
            // Arrange
            // This is a guid from one of the seeded game types
            var gameTypeId = new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0");
            GameType? gameType = null;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                gameType = unitOfWork.GameType.GetById(gameTypeId);

                // If the gameType.Id matches the gameTypeId we've successfully retrieved the gameType from the database
                Assert.Equal(gameTypeId, gameType.Id);
            }
        }

        [Fact]
        public void CanUpdateSingleGameType()
        {
            // Arrange
            // This is a guid from one of the seeded game types
            var seasonId = new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0");
            GameType? gameType = null;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                gameType = unitOfWork.GameType.GetById(seasonId);

                gameType.GameTypeName = "Amended Game Type Name";

                // If the udpdate is successful the unit of work save method will return 1 to indicate 1 record was saved
                Assert.Equal(1, unitOfWork.Save());
            }
        }

        [Fact]
        public void CannotAddTwoGameTypesWithSameName()
        {
            // Arrange
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                // Make up a random gameType name
                string gameTypeName = Guid.NewGuid().ToString();
                unitOfWork.GameType.Add(new GameType { Id = Guid.NewGuid(), GameTypeName = gameTypeName, AwardPoints = true });
                unitOfWork.Save();

                // Act and Assert
                var secondGameType = new GameType { Id = Guid.NewGuid(), GameTypeName = gameTypeName, AwardPoints = false };
                unitOfWork.GameType.Add(secondGameType);
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
