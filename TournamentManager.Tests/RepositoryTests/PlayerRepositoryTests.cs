using EntityFramework.Exceptions.Common;
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
                var exception = Assert.Throws<UniqueConstraintException>(() => unitOfWork.Save());
                var sqlException = exception.InnerException as SqlException;

                if (sqlException != null)
                {
                    // If we get a sqlException of 2601 that means that the insert failed due to the constraint which is what this test is ensuring
                    Assert.Equal(2601, sqlException.Number);
                }
            }
        }

        [Fact]
        public void CanRemovePlayer()
        {
            // Arrange
            Player? player = new Player { FirstName = "This is a", LastName = "Test Player" };
            int result = 0;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);

                if (player != null)
                {
                    unitOfWork.Players.Add(player);
                    unitOfWork.Save();

                    unitOfWork.Players.Remove(player);
                    result = unitOfWork.Save();
                }

                // If the result is greater than zero, we now the data has been affected which means it's been deleted
                Assert.True(result > 0);
            }
        }

        [Fact]
        public void CannotRemoveSeasonIfTheSeasonHasGames()
        {
            // Arrange
            Guid playerId = new Guid("78480ee6-9296-41eb-9914-963f81c61b80");
            Player? player = new Player { Id = playerId, FirstName = "This is a", LastName = "Test Player" };
            Result result = new Result { GameId = new Guid ("6fee60f0-55e4-4cb0-acdc-609de32094be"), Cash = 200, Points = 100, PlayerId = playerId, Position = 999 };

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);

                if (player != null && result != null)
                {
                    unitOfWork.Players.Add(player);
                    unitOfWork.Save();

                    unitOfWork.Results.Add(result);
                    unitOfWork.Save();

                    var exception = Assert.Throws<InvalidOperationException>(() => unitOfWork.Players.Remove(player));
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
