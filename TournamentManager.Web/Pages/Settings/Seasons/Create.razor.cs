using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.Seasons
{
    public partial class Create
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navManager { get; set; } = default!;

        Season Season { get; set; } = new();

    async Task OnSubmit()
    {
            try
            {
                var response = await _apiClient.httpClient.PostAsJsonAsync<Season>("/api/Season/", Season);
                int seasonId = await response.Content.ReadFromJsonAsync<int>();
                if (seasonId > 0)
                {
                    _navManager.NavigateTo("/settings/seasons");
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
        _navManager.NavigateTo("/settings/seasons");
    }
}
}
