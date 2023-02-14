
namespace BooksWebApp.Services.PublisherService
{
    public class PublisherService : IPublisherService
    {
        static string baseURL = "https://books-web-api.azurewebsites.net/api/";
        private readonly HttpClient _client;

        public PublisherService(HttpClient client)
        {
            _client= client;
            _client = new HttpClient { BaseAddress = new Uri(baseURL) };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
            _client.Timeout = TimeSpan.FromMinutes(6);
        }

        public async Task<List<Publisher>> GetPublishersAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("Publishers");
            string responseString = await response.Content.ReadAsStringAsync();
            List<Publisher> publishers = JsonConvert.DeserializeObject<List<Publisher>>(responseString);
            return publishers;
        }

        public async Task<PublisherWithBooksAndAuthorsVM> GetPublisherAsync(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"Publishers/{id}");
            var responseString = await response.Content.ReadAsStringAsync();
            PublisherWithBooksAndAuthorsVM publisher = JsonConvert.DeserializeObject<PublisherWithBooksAndAuthorsVM>(responseString);
            return publisher;
        }

        public async Task AddPublisherAsync(PublisherWithoutId publisher)
        {
            string json = JsonConvert.SerializeObject(publisher);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("Publishers", content);
            string responseString = await response.Content.ReadAsStringAsync();
        }

        public async Task UpdatePublisherAsync(int id, PublisherWithoutId publisher)
        {
            string json = JsonConvert.SerializeObject(publisher);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync($"Publishers/{id}", content);
        }

        public async Task DeletePublisherByIdAsync(int id)
        {
            await _client.DeleteAsync($"Publishers/{id}");
        }

    }
}
