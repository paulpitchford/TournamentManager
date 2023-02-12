namespace TournamentManager.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISeasonRepository Season { get; }

        int Save();
    }
}
