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
            return _context.Games.Include(g => g.Venue).Include(q => q.GameType).Include(g => g.Season).TagWith($"Game Repo: GetAllAscending").OrderBy(g => g.GameDateTime);
        }

        public IEnumerable<Game> GetAllDescending()
        {
            return _context.Games.Include(g => g.Venue).Include(q => q.GameType).Include(g => g.Season).TagWith($"Game Repo: GetAllAscending").OrderByDescending(g => g.GameDateTime);
        }

        public IEnumerable<Game> GetGamesBySeasonAscending(Guid SeasonId)
        {
            return _context.Games.Include(g => g.Venue).Include(q => q.GameType).Include(g => g.Season).Where(g => g.SeasonId == SeasonId).TagWith($"Game Repo: GetGamesBySeasonAscending(SeasonId)").OrderBy(g => g.GameDateTime);
        }

        public IEnumerable<Game> GetGamesBySeasonDescending(Guid SeasonId)
        {
            return _context.Games.Include(g => g.Venue).Include(q => q.GameType).Include(g => g.Season).Where(g => g.SeasonId == SeasonId).TagWith($"Game Repo: GetGamesBySeasonDescending(SeasonId)").OrderByDescending(g => g.GameDateTime);
        }

        public Game? GetGameWithResults(Guid Id)
        {
            return _context.Games.Include(g => g.Venue)
                                 .Include(q => q.GameType)
                                 .Include(g => g.Season).ThenInclude(s => s!.PointStructure).ThenInclude(ps => ps!.PointPositions)
                                 .Include(g => g.Results).ThenInclude(r => r.Player)
                                 .Where(g => g.Id == Id).FirstOrDefault();
        }
    }
}
