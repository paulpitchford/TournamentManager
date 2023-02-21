using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.GameTypes
{
    public partial class Create
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navManager { get; set; } = default!;

        GameType GameType { get; set; } = new();

        async Task OnSubmit()
        {
            var response = await _apiClient.httpClient.PostAsJsonAsync<GameType>("/api/GameTypes/", GameType);

            if (response.IsSuccessStatusCode)
            {
                int gameTypeId = await response.Content.ReadFromJsonAsync<int>();
                if (gameTypeId > 0)
                {
                    _navManager.NavigateTo("/settings/gametypes");
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
            _navManager.NavigateTo("/settings/gametypes");
        }
    }
}
