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
            var response = await _apiClient.httpClient.PostAsJsonAsync<Player>("/api/Players/", Player);

            if (response.IsSuccessStatusCode)
            {
                int playerId = await response.Content.ReadFromJsonAsync<int>();
                if (playerId > 0)
                {
                    _navManager.NavigateTo("/settings/players");
                }
            }
            else
            {
                AlertIsVisible = true;
                Message = await response.Content.ReadAsStringAsync();
                MessageType = AlertMessageType.Danger;
            }
        }

        void OnCancel()
        {
            _navManager.NavigateTo("/settings/players");
        }
    }
}
