using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Interfaces
{
    public interface IPositionFactory
    {
        public int NextPosition(List<int> numbers);
        double CalculatePoints(int position, int playerCount, PointStructure? pointStructure);
    }
}
