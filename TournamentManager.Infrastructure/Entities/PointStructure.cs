using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Infrastructure.Entities
{
    public class PointStructure
    {
        public Guid Id { get; set; }
        public string? PointStructureDescription { get; set; }
        // If no points are added to a position, this is the default amount that will be used
        public double DefaultPoints { get; set; }

        public virtual ICollection<Season> Seasons { get; set; } = new HashSet<Season>();
        public virtual ICollection<PointPosition> PointPositions { get; set; } = new HashSet<PointPosition>();
    }
}
