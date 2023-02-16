using Microsoft.EntityFrameworkCore;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.DataAccess.Repository
{
    public class PointStructureRepository : GenericRepository<PointStructure>, IPointStructureRepository
    {
        public PointStructureRepository(PokerDbContext context) : base(context)
        {
        }

        public IEnumerable<PointStructure> GetAllAscending()
        {
            return _context.PointStructures.OrderBy(ps => ps.PointStructureDescription).TagWith($"Point Structure Repo: GetAllAscening");
        }
    }
}
