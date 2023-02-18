using TournamentManager.Infrastructure.Exceptions;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.Infrastructure.BusinessLogic
{
    public class Position : IPosition
    {
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
