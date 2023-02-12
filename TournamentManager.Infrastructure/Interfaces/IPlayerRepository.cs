using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Interfaces
{
    public interface IPlayerRepository : IGenericRepository<Player>
    {
        IEnumerable<Player> GetAllAscending();
    }
}
