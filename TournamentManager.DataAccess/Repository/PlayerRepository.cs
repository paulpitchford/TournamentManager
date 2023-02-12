using Microsoft.EntityFrameworkCore;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.DataAccess.Repository
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(PokerDbContext context) : base(context) { }

        public IEnumerable<Player> GetAllAscending()
        {
            return _context.Players.TagWith($"Player Repo: GetAllAscending").OrderBy(p => p.FirstName).ThenBy(p => p.LastName);
        }
    }
}
