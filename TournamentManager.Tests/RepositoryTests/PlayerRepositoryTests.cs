using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.RepositoryTests
{
    public class PlayerRepositoryTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public PlayerRepositoryTests(TestDatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CanAddPlayer()
        {
            // Arrange
            var playerId = Guid.NewGuid();
            var player = new Player { Id = playerId, FirstName = "Test", LastName = "Player" };
            int response = 0;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                unitOfWork.Players.Add(player);
                response = unitOfWork.Save();
            }

            // Assert
            Assert.Equal(1, response);
            Assert.Equal(playerId, player.Id);
            Assert.Equal("Test", player.FirstName);
        }

        [Fact]
        public void CanGetSinglePlayer()
        {
            // Arrange
            // This is a guid from one of the seeded players
            var playerId = new Guid("644d7d1a-57d1-4e70-9963-376369fa73cd");
            Player? player;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                player = unitOfWork.Players.GetById(playerId);

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
            Player? player;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                player = unitOfWork.Players.GetById(playerId);

                player.FirstName = "Amended Name";

                // If the udpdate is successful the unit of work save method will return 1 to indicate 1 record was saved
                Assert.Equal(1, unitOfWork.Save());
            }
        }

        [Fact]
        public void CannotAddTwoPlayersWithSameName()
        {
            // Arrange
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                // Make up a random player name
                string tournamentDirectorId = Guid.NewGuid().ToString();
                unitOfWork.Players.Add(new Player { Id = Guid.NewGuid(), FirstName = "Test", LastName = "Player", TournamentDirectorId = tournamentDirectorId });
                unitOfWork.Save();

                // Act and Assert
                var secondPlayer = new Player { Id = Guid.NewGuid(), FirstName = "Another", LastName = "Player", TournamentDirectorId = tournamentDirectorId };
                unitOfWork.Players.Add(secondPlayer);
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
