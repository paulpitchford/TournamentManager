using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Interfaces
{
    public interface IGameRepository : IGenericRepository<Game>
    {
        IEnumerable<Game> GetAllDescending();
        IEnumerable<Game> GetAllAscending();

        IEnumerable<Game> GetGamesBySeasonDescending(Guid SeasonId);
        IEnumerable<Game> GetGamesBySeasonAscending(Guid SeasonId);
    }
}
