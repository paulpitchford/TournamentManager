using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.DataAccess.Repository
{
    internal class PointPositionRepository : GenericRepository<PointPosition>, IPointPositionRepository
    {
        public PointPositionRepository(PokerDbContext context) : base(context)
        {
        }
    }
}
