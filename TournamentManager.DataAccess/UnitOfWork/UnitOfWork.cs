using TournamentManager.Infrastructure.Interfaces;
using TournamentManager.DataAccess.Repository;

namespace TournamentManager.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private PokerDbContext _context;
        public UnitOfWork(PokerDbContext context)
        {
            _context = context;
            Season = new SeasonRepository(_context);
        }
        public ISeasonRepository Season
        {
            get;
            private set;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
