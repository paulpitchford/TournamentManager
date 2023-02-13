using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Interfaces
{
    public interface IPlayersRepository : IGenericRepository<Player>
    {
        IEnumerable<Player> GetAllAscending();
    }
}
