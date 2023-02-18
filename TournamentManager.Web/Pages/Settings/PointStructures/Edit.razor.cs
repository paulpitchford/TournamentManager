using Microsoft.AspNetCore.Components;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Web.Components;
using TournamentManager.Web.Services;

namespace TournamentManager.Web.Pages.Settings.PointStructures
{
    public partial class Edit
    {
        [Inject]
        WebApiService _apiClient { get; set; } = default!;

        [Inject]
        NavigationManager _navManager { get; set; } = default!;

        [Parameter]
        public Guid Id { get; set; }
        PointStructure? PointStructure { get; set; }
        bool formLoading;

        protected override async Task OnInitializedAsync()
        {
            formLoading = true;
            PointStructure = await _apiClient.httpClient.GetFromJsonAsync<PointStructure>($"/api/PointStructures/{Id}");
            formLoading = false;
        }

        async Task OnSubmit()
        {
            if (PointStructure != null)
            {
                try
                {
                    var response = await _apiClient.httpClient.PutAsJsonAsync<PointStructure>($"/api/PointStructures/{Id}", PointStructure);
                    bool updated = await response.Content.ReadFromJsonAsync<bool>();

                    if (updated)
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
        }

        void OnCancel()
        {
            _navManager.NavigateTo("/settings/pointstructures");
        }
    }
}
