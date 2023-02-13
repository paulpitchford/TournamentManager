using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Interfaces
{
    public interface IResultsRepository : IGenericRepository<Result>
    {
        IEnumerable<Result> GetResultsByGame(Guid GameId);
        IEnumerable<Result> GetResultsByPlayer(Guid PlayerId);
    }
}
