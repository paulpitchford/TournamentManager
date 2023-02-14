using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.Players
{
    public partial class Create
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navManager { get; set; } = default!;

        Player Player { get; set; } = new();

        async Task OnSubmit()
        {
            try
            {
                var response = await _apiClient.httpClient.PostAsJsonAsync<Player>("/api/Players/", Player);
                int playerId = await response.Content.ReadFromJsonAsync<int>();
                if (playerId > 0)
                {
                    _navManager.NavigateTo("/settings/players");
                }
            }
            catch (Exception ex)
            {
                AlertIsVisible = true;
                Message = ex.Message;
                MessageType = AlertMessageType.Danger;
            }
        }

        void OnCancel()
        {
            _navManager.NavigateTo("/settings/players");
        }
    }
}
