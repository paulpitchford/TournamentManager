using EntityFramework.Exceptions.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.RepositoryTests
{
    public class GameTypeRepositoryTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public GameTypeRepositoryTests(TestDatabaseFixture fixture)
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
                unitOfWork.GameTypes.Add(gameType);
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
                gameType = unitOfWork.GameTypes.GetById(gameTypeId);

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
                gameType = unitOfWork.GameTypes.GetById(seasonId);

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
                unitOfWork.GameTypes.Add(new GameType { Id = Guid.NewGuid(), GameTypeName = gameTypeName, AwardPoints = true });
                unitOfWork.Save();

                // Act and Assert
                var secondGameType = new GameType { Id = Guid.NewGuid(), GameTypeName = gameTypeName, AwardPoints = false };
                unitOfWork.GameTypes.Add(secondGameType);
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
        public void CannotAddTwoGameTypesWithIsDefaultTrue()
        {
            // Arrange
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                // Make up a random season name
                string gameTypeName = Guid.NewGuid().ToString();
                
                // Act and Assert
                // The seed data already has a game type where IsDefault = true so there is no need to create two objects in this test.
                // We can just add this second one and the test should pass because we should get the SQL Exception 2601.
                var secondGameType = new GameType { Id = Guid.NewGuid(), GameTypeName = gameTypeName, AwardPoints = false, IsDefault = true };
                unitOfWork.GameTypes.Add(secondGameType);
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
        public void CanRemoveGameType()
        {
            // Arrange
            GameType? gameType = new GameType { AwardPoints = true, GameTypeName = "This is a Test Game Type", IsDefault = false };
            int result = 0;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);

                if (gameType != null)
                {
                    unitOfWork.GameTypes.Add(gameType);
                    unitOfWork.Save();

                    unitOfWork.GameTypes.Remove(gameType);
                    result = unitOfWork.Save();
                }

                // If the result is greater than zero, we now the data has been affected which means it's been deleted
                Assert.True(result > 0);
            }
        }

        [Fact]
        public void CannotRemoveGameTypeIfTheGameTypeHasGames()
        {
            // Arrange
            Guid gameTypeId = Guid.NewGuid();
            GameType? gameType = new GameType { Id = gameTypeId, AwardPoints = true, GameTypeName = "This is a Test Game Type", IsDefault = false };
            Game? game = new Game { SeasonId = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e"), Buyin = 35, Fee = 5, GameDateTime = DateTime.Now.AddDays(7), GameDetails = "Test Game", GameTitle = "Test Game", GameTypeId = gameTypeId, VenueId = new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d"), PublishResults = false };

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);

                if (gameType != null && game != null)
                {
                    unitOfWork.GameTypes.Add(gameType);
                    unitOfWork.Save();

                    unitOfWork.Games.Add(game);
                    unitOfWork.Save();

                    unitOfWork.GameTypes.Remove(gameType);

                    var exception = Assert.Throws<CannotInsertNullException>(() => unitOfWork.Save());
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
