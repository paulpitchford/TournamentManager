namespace TournamentManager.Infrastructure.Entities
{
    public class Season
    {
        public Guid Id { get; set; }
        public string? SeasonName { get; set; }
        public DateTime StartDate { get; set; }

        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}
