namespace TournamentManager.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGameTypeRepository GameType { get; }
        IPlayerRepository Player { get; }
        ISeasonRepository Season { get; }
        IVenueRepository Venue { get; }

        int Save();
    }
}
