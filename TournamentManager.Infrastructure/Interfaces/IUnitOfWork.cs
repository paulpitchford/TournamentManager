namespace TournamentManager.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISeasonRepository Season { get; }

        IGameTypeRepository GameType { get; }

        int Save();
    }
}
