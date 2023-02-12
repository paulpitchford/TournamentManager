namespace TournamentManager.Web.Services
{
    public class WebApiService
    {
        public HttpClient httpClient { get; }

        public WebApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            httpClient.BaseAddress = new Uri("https://localhost:7281/");
        }
    }
}
