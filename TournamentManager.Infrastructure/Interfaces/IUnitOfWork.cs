namespace TournamentManager.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGameRepository Game { get; }
        IGameTypeRepository GameType { get; }
        IPlayerRepository Player { get; }
        ISeasonRepository Season { get; }
        IVenueRepository Venue { get; }

        int Save();
    }
}
