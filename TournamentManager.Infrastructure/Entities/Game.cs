namespace TournamentManager.Infrastructure.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public Guid? SeasonId { get; set; }
        public Guid? GameTypeId { get; set; }
        public Guid? VenueId { get; set; }
        public string? GameTitle { get; set; }
        public DateTime GameDateTime { get; set; }
        public bool PublishResults { get; set; }
        public string? GameDetails { get; set; }
        public double Buyin { get; set; }
        public double Fee { get; set; }

        public virtual Season Season { get; set; } = default!;
        public virtual GameType GameType { get; set; } = default!;
        public virtual Venue Venue { get; set; } = default!;
    }
}
