using Microsoft.AspNetCore.Components;

namespace TournamentManager.Web.Components
{
    public class PokerBaseComponent : ComponentBase
    {
        public bool AlertIsVisible { get; set; }
        public string? Message { get; set; }
        public AlertMessageType MessageType { get; set; }
    }
}
