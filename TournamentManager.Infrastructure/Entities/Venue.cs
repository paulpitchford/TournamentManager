namespace TournamentManager.Infrastructure.Entities
{
    public class Venue
    {
        public Guid Id { get; set; } 
        public string? VenueName { get; set; }
        public string? Address { get; set; }
        public string? Town { get; set; }
        public string? County { get; set; }
        public string? PostCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WebAddress { get; set; }
        public string? FacebookAddress { get; set; }
        public string? ExtraInformation { get; set; }
    }
}
