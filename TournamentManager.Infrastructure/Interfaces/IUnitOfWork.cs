namespace TournamentManager.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGamesRepository Games { get; }
        IGameTypesRepository GameTypes { get; }
        IPlayersRepository Players { get; }
        IPointStructureRepository PointStructures { get; } 
        IPointPositionRepository PointPositions { get; }
        IResultsRepository Results { get; }
        ISeasonsRepository Seasons { get; }
        IVenuesRepository Venues { get; }

        int Save();
    }
}
