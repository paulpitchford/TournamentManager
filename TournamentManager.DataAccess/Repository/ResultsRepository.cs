using Microsoft.EntityFrameworkCore;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.DataAccess.Repository
{
    public class ResultsRepository : GenericRepository<Result>, IResultsRepository
    {
        public ResultsRepository(PokerDbContext context) : base(context)
        {
        }

        public IEnumerable<Result> GetResultsByGame(Guid GameId)
        {
            return _context.Results.Where(r => r.GameId == GameId).TagWith($"Result Repo: GetResultsByGame(GameId)").OrderBy(r => r.Position);
        }

        public IEnumerable<Result> GetResultsByPlayer(Guid PlayerId)
        {
            return _context.Results.Where(r => r.PlayerId == PlayerId).TagWith($"Result Repo: GetResultsByPlayer(PlayerId)").OrderBy(r => r.Position);
        }
    }
}
