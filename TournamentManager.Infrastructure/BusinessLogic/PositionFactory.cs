using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Exceptions;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.Infrastructure.BusinessLogic
{
    public class PositionFactory : IPositionFactory
    {
        public double CalculatePoints(int position, int playerCount, PointStructure? pointStructure)
        {
            if (pointStructure != null)
            {
                double points = 0;
                points += pointStructure.DefaultPoints;

                // See if this position is in the points structure points collection
                PointPosition? pointPosition = pointStructure.PointPositions.Where(pp => pp.Position== position).FirstOrDefault();

                // If it is use it
                if (pointPosition != null) { 
                    if (pointPosition.MultiplierType == Enums.PointPositionMultiplierType.PlayerCount)
                    {
                        points += (playerCount * pointPosition.Points);
                    }
                    else if (pointPosition.MultiplierType == Enums.PointPositionMultiplierType.MultiplierValue)
                    {
                        points += (pointPosition.MultiplierValue * pointPosition.Points);
                    }
                }

                return points;
            }
            else
            {
                return 0;
            }
        }

        public int NextPosition(List<int> numbers)
        {
            // This method takes the list and returns the next lowest value down to 1.
            // If 2 is the first number in the collection, 1 is returned.
            // If no missing number is found it basically returns max + 1.

            // First we sort it
            numbers = numbers.Order().ToList();

            int expected = 1;
            foreach (int number in numbers)
            {
                if (number == 0)
                {
                    throw new SortedPositionListContainsZeroException("The position list should not contain a item of 0.");
                }
                if (number == expected)
                {
                    expected++;
                }
                else
                {
                    return expected;
                }
            }
            return expected;
        }
    }
}
