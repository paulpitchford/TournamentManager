using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.PointStructures
{
    public partial class Index
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navigationManager { get; set; } = default!;

        bool gridLoading;
        IEnumerable<PointStructure>? PointStructures;
        PointStructure? selectedPointStructure;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                gridLoading = true;
                PointStructures = await _apiClient.httpClient.GetFromJsonAsync<IEnumerable<PointStructure>>("/api/PointStructures/");
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
            _navigationManager.NavigateTo("/settings/pointstructures/create");
        }

        void Edit(Guid Id)
        {
            _navigationManager.NavigateTo($"/settings/pointstructures/{Id}");
        }
    }
}
