
using EntityFramework.Exceptions.Common;
using Microsoft.Data.SqlClient;
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Enums;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.RepositoryTests
{
    public class PointStructureTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public PointStructureTests(TestDatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CanAddPointStructure()
        {
            // Arrange
            var pointStructureId = Guid.NewGuid();
            var pointStructure = new PointStructure
            {
                Id = pointStructureId,
                DefaultPoints = 15,
                PointStructureDescription = "Test Description"
            };

            int response = 0;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                unitOfWork.PointStructures.Add(pointStructure);
                response = unitOfWork.Save();
            }

            // Assert
            Assert.Equal(1, response);
            Assert.Equal(pointStructureId, pointStructure.Id);
        }

        [Fact]
        public void CanGetSinglePointStructure()
        {
            // Arrange
            // This is a guid from one of the seeded pointStructures
            var pointStructureId = new Guid("d9db6444-f33f-4832-befe-46a17ea765cf");
            PointStructure? pointStructure;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                pointStructure = unitOfWork.PointStructures.GetById(pointStructureId);

                // If the pointStructure.Id matches the pointStructureId we've successfully retrieved the pointStructure from the database
                Assert.Equal(pointStructureId, pointStructure.Id);
            }
        }

        [Fact]
        public void CanUpdateSinglePointStructure()
        {
            // Arrange
            // This is a guid from one of the seeded pointStructures
            var pointStructureId = new Guid("d9db6444-f33f-4832-befe-46a17ea765cf");
            PointStructure? pointStructure;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                pointStructure = unitOfWork.PointStructures.GetById(pointStructureId);

                pointStructure.DefaultPoints = 20;

                // If the udpdate is successful the unit of work save method will return 1 to indicate 1 record was saved
                Assert.Equal(1, unitOfWork.Save());
            }
        }

        [Fact]
        public void CanRemovePointStructure()
        {
            // Arrange
            PointStructure? pointStructure = new PointStructure { DefaultPoints = 15, PointStructureDescription = "Test Point Structure to Delete" };
            int result = 0;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);

                if (pointStructure != null)
                {
                    unitOfWork.PointStructures.Add(pointStructure);
                    unitOfWork.Save();

                    unitOfWork.PointStructures.Remove(pointStructure);
                    result = unitOfWork.Save();
                }

                // If the result is greater than zero, we now the data has been affected which means it's been deleted
                Assert.True(result > 0);
            }
        }

        [Fact]
        public void CannotRemovePointStructureIfThePointStructureHasSeasons()
        {
            // Arrange
            Guid pointStructureId = new Guid("012f5eef-2f88-4e4b-ac5e-3e71cfb03d29");
            PointStructure? pointStructure = new PointStructure { Id = pointStructureId, DefaultPoints = 15, PointStructureDescription = "Test Points Structure to delete." };
            Season? season = new Season { PointStructureId = pointStructureId, SeasonName = "Points Structure Test Season", StartDate = DateTime.Today };
            pointStructure.Seasons.Add(season);

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);

                if (pointStructure != null)
                {
                    unitOfWork.PointStructures.Add(pointStructure);
                    unitOfWork.Save();

                    unitOfWork.PointStructures.Remove(pointStructure);

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

        [Fact]
        public void CanRemovePointStructureWhenHasPointPositions()
        {
            // Arrange
            Guid pointStructureId = new Guid("8c1ed506-ff08-42e4-b477-057f6ee2372c");
            PointStructure? pointStructure = new PointStructure { Id = pointStructureId, DefaultPoints = 15, PointStructureDescription = "Test Point Structure to Delete" };
            PointPosition? pointPosition = new PointPosition { PointStructureId = pointStructureId, MultiplierType = PointPositionMultiplierType.PlayerCount, MultiplierValue = 0, Position = 1, Points = 10 };
            pointStructure.PointPositions.Add(pointPosition);
            int result = 0;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);

                if (pointStructure != null)
                {
                    unitOfWork.PointStructures.Add(pointStructure);
                    unitOfWork.Save();

                    unitOfWork.PointStructures.Remove(pointStructure);
                    result = unitOfWork.Save();
                }

                // If the result is greater than zero, we now the data has been affected which means it's been deleted
                Assert.True(result > 0);
            }
        }
    }
}
