using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.Venues
{
    public partial class Index
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navigationManager { get; set; } = default!;

        bool gridLoading;
        IEnumerable<Venue>? Venues;
        Venue? selectedVenue;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                gridLoading = true;
                Venues = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<Venue>>("/api/Venues/");
                gridLoading = false;
            }
            catch (Exception ex)
            {
                gridLoading = false;
                AlertIsVisible = true;
                Message = ex.Message;
                MessageType = AlertMessageType.Danger;
            }
        }

        void CreateNew()
        {
            _navigationManager.NavigateTo("/settings/venues/create");
        }

        void Edit(Guid Id)
        {
            _navigationManager.NavigateTo($"/settings/venues/{Id}");
        }
    }
}
