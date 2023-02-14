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
            try
            {
                var response = await _apiClient.httpClient.PostAsJsonAsync<GameType>("/api/GameTypes/", GameType);
                int gameTypeId = await response.Content.ReadFromJsonAsync<int>();
                if (gameTypeId > 0)
                {
                    _navManager.NavigateTo("/settings/gametypes");
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
            _navManager.NavigateTo("/settings/gametypes");
        }
    }
}
