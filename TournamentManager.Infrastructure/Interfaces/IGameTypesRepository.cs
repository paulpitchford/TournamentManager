using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Interfaces
{
    public interface IGameTypesRepository : IGenericRepository<GameType>
    {
        IEnumerable<GameType> GetAllAscending();
    }
}
