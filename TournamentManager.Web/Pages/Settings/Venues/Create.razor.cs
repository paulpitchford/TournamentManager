using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.Venues
{
    public partial class Create
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navManager { get; set; } = default!;

        Venue Venue { get; set; } = new();

        async Task OnSubmit()
        {
            try
            {
                var response = await _apiClient.httpClient.PostAsJsonAsync<Venue>("/api/Venues/", Venue);
                int venueId = await response.Content.ReadFromJsonAsync<int>();
                if (venueId > 0)
                {
                    _navManager.NavigateTo("/settings/venues");
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
            _navManager.NavigateTo("/settings/venues");
        }
    }
}
