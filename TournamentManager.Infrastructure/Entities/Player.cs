using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Infrastructure.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? TournamentDirectorId { get; set; }

        public virtual ICollection<Result> Results { get; set; } = new HashSet<Result>();
    }
}
