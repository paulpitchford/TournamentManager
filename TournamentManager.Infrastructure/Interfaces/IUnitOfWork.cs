namespace TournamentManager.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISeasonRepository Season { get; }

        IGameTypeRepository GameType { get; }

        IVenueRepository Venue { get; }

        int Save();
    }
}
