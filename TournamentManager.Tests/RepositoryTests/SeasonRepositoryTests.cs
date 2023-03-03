using EntityFramework.Exceptions.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.RepositoryTests
{
    public class SeasonRepositoryTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public SeasonRepositoryTests(TestDatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CanAddSeason()
        {
            // Arrange
            var seasonId = Guid.NewGuid();
            var seasonName = Guid.NewGuid().ToString();
            var season = new Season { Id = seasonId, SeasonName = seasonName, StartDate = DateTime.Today, PointStructureId = new Guid("d9db6444-f33f-4832-befe-46a17ea765cf") };
            int response = 0;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                unitOfWork.Seasons.Add(season);
                response = unitOfWork.Save();
            }

            // Assert
            Assert.Equal(1, response);
            Assert.Equal(seasonId, season.Id);
            Assert.Equal(seasonName, season.SeasonName);
        }

        [Fact]
        public void CanGetSingleSeason()
        {
            // Arrange
            // This is a guid from one of the seeded seasons
            var seasonId = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e");
            Season? season;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                season = unitOfWork.Seasons.GetById(seasonId);

                // If the season.Id matches the seasonId we've successfully retrieved the season from the database
                Assert.Equal(seasonId, season.Id);
            }
        }

        [Fact]
        public void CanUpdateSingleSeason()
        {
            // Arrange
            // This is a guid from one of the seeded seasons
            var seasonId = new Guid("1b0c1ad0-e4f5-4fb6-98a4-e5e2a2d5e24e");
            Season? season;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                season = unitOfWork.Seasons.GetById(seasonId);

                season.StartDate = DateTime.Now;

                // If the udpdate is successful the unit of work save method will return 1 to indicate 1 record was saved
                Assert.Equal(1, unitOfWork.Save());
            }
        }

        [Fact]
        public void CannotAddTwoSeasonsWithSameName()
        {
            // Arrange
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                // Make up a random season name
                string seasonName = Guid.NewGuid().ToString();
                unitOfWork.Seasons.Add(new Season { Id = Guid.NewGuid(), SeasonName = seasonName, StartDate = DateTime.Today, PointStructureId = new Guid("d9db6444-f33f-4832-befe-46a17ea765cf") });
                unitOfWork.Save();

                // Act and Assert
                var secondSeason = new Season { Id = Guid.NewGuid(), SeasonName = seasonName, StartDate = DateTime.Today, PointStructureId = new Guid("d9db6444-f33f-4832-befe-46a17ea765cf") };
                unitOfWork.Seasons.Add(secondSeason);
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
        public void CanRemoveSeason()
        {
            // Arrange
            // This is a guid from one of the seeded seasons
            var seasonId = new Guid("a78ca768-37e6-4ca7-889d-2c00158bb382");
            Season? season = new Season { Id = seasonId, SeasonName = "Season to Delete", StartDate = DateTime.Today, PointStructureId = new Guid("d9db6444-f33f-4832-befe-46a17ea765cf") };
            int result = 0;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);

                if (season != null)
                {
                    unitOfWork.Seasons.Add(season);
                    unitOfWork.Save();

                    unitOfWork.Seasons.Remove(season);
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
            Season? season = new Season { SeasonName = "Season to Delete with Games", StartDate = DateTime.Today, PointStructureId = new Guid("d9db6444-f33f-4832-befe-46a17ea765cf") };
            Game? game = new Game { Id = new Guid("6bd7d582-b11b-4ac3-9f07-e3b517ab561b"), Buyin = 35, Fee = 5, GameDateTime = DateTime.Now.AddDays(7), GameDetails = "Test Game", GameTitle = "Test Game", GameTypeId = new Guid("dbb07104-cffa-4539-91ce-1d0e5ecce2e0"), VenueId = new Guid("63c0255e-ecde-4edf-8a7f-3ecf026bba3d"), PublishResults = false };
            season.Games.Add(game);

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);

                if (season != null)
                {
                    unitOfWork.Seasons.Add(season);
                    unitOfWork.Save();

                    unitOfWork.Seasons.Remove(season);

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
