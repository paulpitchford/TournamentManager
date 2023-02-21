using Microsoft.EntityFrameworkCore;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.DataAccess.Repository
{
    public class GamesRepository : GenericRepository<Game>, IGamesRepository
    {
        public GamesRepository(PokerDbContext context) : base(context)
        {
        }

        public IEnumerable<Game> GetAllAscending()
        {
            return _context.Games.Include(g => g.Venue).Include(g => g.GameType).Include(g => g.Season).Include(g => g.Results).TagWith($"Game Repo: GetAllAscending").OrderBy(g => g.GameDateTime).AsNoTracking().ToList();
        }

        public IEnumerable<Game> GetAllDescending()
        {
            return _context.Games.Include(g => g.Venue).Include(g => g.GameType).Include(g => g.Season).Include(g => g.Results).TagWith($"Game Repo: GetAllAscending").OrderByDescending(g => g.GameDateTime).AsNoTracking().ToList();
        }

        public IEnumerable<Game> GetGamesBySeasonAscending(Guid SeasonId)
        {
            return _context.Games.Include(g => g.Venue).Include(g => g.GameType).Include(g => g.Season).Include(g => g.Results).Where(g => g.SeasonId == SeasonId).TagWith($"Game Repo: GetGamesBySeasonAscending(SeasonId)").OrderBy(g => g.GameDateTime).AsNoTracking().ToList();
        }

        public IEnumerable<Game> GetGamesBySeasonDescending(Guid SeasonId)
        {
            return _context.Games.Include(g => g.Venue).Include(g => g.GameType).Include(g => g.Season).Include(g => g.Results).Where(g => g.SeasonId == SeasonId).TagWith($"Game Repo: GetGamesBySeasonDescending(SeasonId)").OrderByDescending(g => g.GameDateTime).AsNoTracking().ToList();
        }

        public Game? GetGameWithResults(Guid Id)
        {
            return _context.Games.Include(g => g.Venue)
                                 .Include(q => q.GameType)
                                 .Include(g => g.Season).ThenInclude(s => s!.PointStructure).ThenInclude(ps => ps!.PointPositions)
                                 .Include(g => g.Results).ThenInclude(r => r.Player).ThenInclude(p => p.Results)
                                 .Where(g => g.Id == Id).FirstOrDefault();
        }
    }
}
