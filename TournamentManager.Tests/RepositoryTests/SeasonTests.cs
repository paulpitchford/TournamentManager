using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.RepositoryTests
{
    public class SeasonTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public SeasonTests(TestDatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CanAddSeason()
        {
            // Arrange
            var seasonId = Guid.NewGuid();
            var seasonName = Guid.NewGuid().ToString();
            var season = new Season { Id = seasonId, SeasonName = seasonName, StartDate = DateTime.Today };
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
                unitOfWork.Seasons.Add(new Season { Id = Guid.NewGuid(), SeasonName = seasonName, StartDate = DateTime.Today });
                unitOfWork.Save();

                // Act and Assert
                var secondSeason = new Season { Id = Guid.NewGuid(), SeasonName = seasonName, StartDate = DateTime.Today };
                unitOfWork.Seasons.Add(secondSeason);
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
