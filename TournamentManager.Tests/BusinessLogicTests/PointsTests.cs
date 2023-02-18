using TournamentManager.Infrastructure.Exceptions;
using TournamentManager.Tests.Fixtures;

namespace TournamentManager.Tests.BusinessLogicTests
{
    public class PointsTests : IClassFixture<PositionFactoryFixtures>
    {
        private PositionFactoryFixtures _fixture;

        public PointsTests(PositionFactoryFixtures fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ExpectedNumber7IsReturned()
        {
            // Arrange 
            // This list is missing number 7
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 8, 9, 10, 11, 12 };

            // Act
            int missingNumber = _fixture.PositionFactory.NextPosition(numbers);

            // Assert
            Assert.Equal(7, missingNumber);
        }

        [Fact]
        public void ExpectedNumber1IsReturned()
        {
            // Arrange 
            // This list is missing number 7
            List<int> numbers = new List<int> { 2, 3, 4, 5, 6, 8, 9, 10, 11, 12 };

            // Act
            int missingNumber = _fixture.PositionFactory.NextPosition(numbers);

            // Assert
            Assert.Equal(1, missingNumber);
        }

        [Fact]
        public void ExpectedNumber3IsReturned()
        {
            // Arrange 
            // This list is missing number 7
            List<int> numbers = new List<int> { 1, 2, 8, 9, 10, 11, 12 };

            // Act
            int missingNumber = _fixture.PositionFactory.NextPosition(numbers);

            // Assert
            Assert.Equal(3, missingNumber);
        }

        [Fact]
        public void ExpectedNumber4IsReturned()
        {
            // Arrange 
            // This list is missing number 7
            List<int> numbers = new List<int> { 1, 2, 8, 9, 10, 11, 12 };

            // Act
            // 3 should be returned
            int missingNumber = _fixture.PositionFactory.NextPosition(numbers);
            // Add it to the collection
            numbers.Add(missingNumber);
            // Order the list again as the new number will be at the bottom
            numbers = numbers.Order().ToList();
            // Run it again to get 4
            missingNumber = _fixture.PositionFactory.NextPosition(numbers);

            // Assert
            Assert.Equal(4, missingNumber);
        }

        [Fact]
        public void ThrowExceptionIfZeroFoundInListOfInt()
        {
            // Arrange 
            List<int> numbers = Enumerable.Range(0, 10).ToList();
            int missingNumber = 0;
            
            // Act & Assert
            Assert.Throws<SortedPositionListContainsZeroException>(() => missingNumber = _fixture.PositionFactory.NextPosition(numbers));
        }
    }
}
