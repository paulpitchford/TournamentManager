using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Infrastructure.Entities
{
    public class GameType
    {
        public Guid Id { get; set; }
        public string? GameTypeName { get; set; }
        public bool AwardPoints { get; set; }

        public ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}
