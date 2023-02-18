using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.PointStructures
{
    public partial class Create
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navManager { get; set; } = default!;

        PointStructure PointStructure { get; set; } = new();

        async Task OnSubmit()
        {
            try
            {
                var response = await _apiClient.httpClient.PostAsJsonAsync<PointStructure>("/api/PointStructures/", PointStructure);
                int pointStructureId = await response.Content.ReadFromJsonAsync<int>();
                if (pointStructureId > 0)
                {
                    _navManager.NavigateTo("/settings/pointstructures");
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
            _navManager.NavigateTo("/settings/pointstructures");
        }
    }
}
