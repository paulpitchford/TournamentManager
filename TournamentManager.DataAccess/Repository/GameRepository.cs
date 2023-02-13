using Microsoft.EntityFrameworkCore;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.DataAccess.Repository
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(PokerDbContext context) : base(context)
        {
        }

        public IEnumerable<Game> GetAllAscending()
        {
            return _context.Games.TagWith($"Game Repo: GetAllAscending").OrderBy(g => g.GameDateTime);
        }

        public IEnumerable<Game> GetAllDescending()
        {
            return _context.Games.TagWith($"Game Repo: GetAllAscending").OrderByDescending(g => g.GameDateTime);
        }

        public IEnumerable<Game> GetGamesBySeasonAscending(Guid SeasonId)
        {
            return _context.Games.Where(g => g.SeasonId == SeasonId).TagWith($"Game Repo: GetGamesBySeasonAscending(SeasonId)").OrderBy(g => g.GameDateTime);
        }

        public IEnumerable<Game> GetGamesBySeasonDescending(Guid SeasonId)
        {
            return _context.Games.Where(g => g.SeasonId == SeasonId).TagWith($"Game Repo: GetGamesBySeasonDescending(SeasonId)").OrderByDescending(g => g.GameDateTime);
        }
    }
}
