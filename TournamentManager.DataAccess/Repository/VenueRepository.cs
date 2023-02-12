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
    public class VenueRepository : GenericRepository<Venue>, IVenueRepository
    {
        public VenueRepository(PokerDbContext context) : base(context) { }

        public IEnumerable<Venue> GetAllAscending()
        {
            return _context.Venues.TagWith($"Venue Repo: GetAllAscending").OrderBy(v => v.VenueName);
        }
    }
}
