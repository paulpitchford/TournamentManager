
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
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
    }
}
