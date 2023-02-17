using TournamentManager.Infrastructure.Entities;

namespace TournamentManager.Infrastructure.Interfaces
{
    public interface IPointStructureRepository : IGenericRepository<PointStructure>
    {
        IEnumerable<PointStructure> GetAllAscending();
        PointStructure? GetPointStructureWithPoints(Guid Id);
    }
}
