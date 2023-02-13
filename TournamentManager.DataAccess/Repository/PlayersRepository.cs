using Microsoft.EntityFrameworkCore;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.DataAccess.Repository
{
    public class PlayersRepository : GenericRepository<Player>, IPlayersRepository
    {
        public PlayersRepository(PokerDbContext context) : base(context) { }

        public IEnumerable<Player> GetAllAscending()
        {
            return _context.Players.TagWith($"Player Repo: GetAllAscending").OrderBy(p => p.FirstName).ThenBy(p => p.LastName);
        }
    }
}
