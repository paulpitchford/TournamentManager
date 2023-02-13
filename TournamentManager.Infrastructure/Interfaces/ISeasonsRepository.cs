using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Interfaces
{
    public interface ISeasonsRepository : IGenericRepository<Season>
    {
        IEnumerable<Season> GetAllByDateDesc();
    }
}
