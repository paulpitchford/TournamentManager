using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.DataAccess.Repository
{
    public class GameTypeRepository : GenericRepository<GameType>, IGameTypeRepository
    {
        public GameTypeRepository(PokerDbContext context) : base(context) { }

        public IEnumerable<GameType> GetAllAscending()
        {
            return _context.GameTypes.TagWith($"Game Type Repo: GetAllAscending").OrderBy(gt => gt.GameTypeName);
        }
    }
}
