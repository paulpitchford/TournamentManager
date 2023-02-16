using TournamentManager.API.Controllers;
using TournamentManager.DataAccess.UnitOfWork;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.ControllerTests
{
    public class PointStructureControllerTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public PointStructureControllerTests(TestDatabaseFixture fixture)
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

            // Act
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new PointStructuresController(unitOfWork);

                response = controller.AddPointStructure(pointStructure);
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

            // Act and Assert
            // When we're creating a controller test, we still have to instatiate the unitofwork to pass into the controller
            using (var context = _fixture.CreateContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var controller = new PointStructuresController(unitOfWork);

                pointStructure = controller.GetPointStructure(pointStructureId);

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
            var pointStructureDescription = Guid.NewGuid().ToString();
            PointStructure? pointStructure;

            using (var context = _fixture.CreateContext())
            {
                // Act and Assert
                var unitOfWork = new UnitOfWork(context);
                var controller = new PointStructuresController(unitOfWork);

                pointStructure = controller.GetPointStructure(pointStructureId);
                pointStructure.PointStructureDescription = pointStructureDescription;

                // If the udpdate is successful the unit of work save method will return 1 to indicate 1 record was saved
                Assert.True(controller.UpdatePointStructure(pointStructureId, pointStructure));
            }
        }
    }
}
