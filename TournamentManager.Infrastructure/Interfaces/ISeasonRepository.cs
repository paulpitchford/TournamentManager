using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Interfaces
{
    public interface ISeasonRepository : IGenericRepository<Season>
    {
        IEnumerable<Season> GetAllByDateDesc();
    }
}
