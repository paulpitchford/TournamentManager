using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.Venues
{
    public partial class Edit
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navManager { get; set; } = default!;

        [Parameter]
        public Guid Id { get; set; }
        Venue? Venue { get; set; }
        bool formLoading;

        protected override async Task OnInitializedAsync()
        {
            formLoading = true;
            Venue = await _apiClient.httpClient.GetFromJsonAsync<Venue>($"/api/Venues/{Id}");
            formLoading = false;
        }

        async Task OnSubmit()
        {
            if (Venue != null)
            {
                try
                {
                    var response = await _apiClient.httpClient.PutAsJsonAsync<Venue>($"/api/Venues/{Id}", Venue);
                    bool updated = await response.Content.ReadFromJsonAsync<bool>();

                    if (updated)
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
        }

        void OnCancel()
        {
            _navManager.NavigateTo("/settings/venues");
        }
    }
}
