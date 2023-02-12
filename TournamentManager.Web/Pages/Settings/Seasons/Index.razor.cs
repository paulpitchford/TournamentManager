using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.Seasons
{
    public partial class Index
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navigationManager { get; set; } = default!;

        bool gridLoading;
        IEnumerable<Season>? Seasons;
        Season? selectedSeason;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                gridLoading = true;
                Seasons = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<Season>>("/api/Season/");
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
            _navigationManager.NavigateTo("/settings/seasons/create");
        }

        void Edit(Guid Id)
        {
            _navigationManager.NavigateTo($"/settings/seasons/{Id}");
        }
    }
}
