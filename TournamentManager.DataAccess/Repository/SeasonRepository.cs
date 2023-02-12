using Microsoft.EntityFrameworkCore;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.DataAccess.Repository
{
    public class SeasonRepository : GenericRepository<Season>, ISeasonRepository
    {
        public SeasonRepository(PokerDbContext context) : base(context) { }

        public IEnumerable<Season> GetAllByDateDesc()
        {
            return _context.Seasons.TagWith($"Season Repo: GetAllByDateDesc").OrderByDescending(s => s.StartDate);
        }
    }
}
