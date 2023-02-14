using BooksWebApp.Helpers;
using BooksWebApp.Models;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;

namespace BooksWebApp.Services.AccountService
{
    public class AccountService : IAccountService
    {
        static string? baseURL;
        private readonly HttpClient _client;
        private readonly Settings settings;

        public AccountService(HttpClient client, IOptions<Settings> option)
        {
            settings = option.Value;
            baseURL = settings.ApiBaseUrl;
            _client = client;
            _client = new HttpClient { BaseAddress = new Uri(baseURL) };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.Timeout = TimeSpan.FromMinutes(6);
        }

        public async Task<Response> LoginAsync(Login login)
        {
            string json = JsonConvert.SerializeObject(login);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("Account/Login", content);
            string responseString = await response.Content.ReadAsStringAsync();
            Response result = JsonConvert.DeserializeObject<Response>(responseString);
            return result;
        }

        public Task<Response> RegisterAsync(Register model)
        {
            throw new NotImplementedException();
        }
    }
}
