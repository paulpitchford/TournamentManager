using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Interfaces
{
    public interface IGameTypeRepository : IGenericRepository<GameType>
    {
        IEnumerable<GameType> GetAllAscending();
    }
}
