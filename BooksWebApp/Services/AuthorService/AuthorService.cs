
namespace BooksWebApp.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        static string baseURL = "https://localhost:44312/api/";
        private readonly HttpClient _client;

        public AuthorService(HttpClient client)
        {
            _client= client;
            _client = new HttpClient { BaseAddress = new Uri(baseURL) };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.Timeout = TimeSpan.FromMinutes(6);
        }

        public async Task<List<Authors>> GetAuthorsAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("Authors");
            string responseString = await response.Content.ReadAsStringAsync();
            List<Authors> authors = JsonConvert.DeserializeObject<List<Authors>>(responseString);
            return authors;
        }

        public async Task<Author> GetAuthorAsync(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"Authors/{id}");
            string responseString = await response.Content.ReadAsStringAsync();
            Author author = JsonConvert.DeserializeObject<Author>(responseString);
            return author;
        }

        public async Task AddAuthorAsync(AuthorWithoutId author)
        {
            string json = JsonConvert.SerializeObject(author);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("Authors", content);
            string responseString = await response.Content.ReadAsStringAsync();
            Book addedBook = JsonConvert.DeserializeObject<Book>(responseString);
        }

        public async Task DeleteAuthorByIdAsync(int id)
        {
            await _client.DeleteAsync($"authors/{id}");
            HttpResponseMessage response = await _client.GetAsync($"authors/{id}");
            string responsestring = await response.Content.ReadAsStringAsync();
            Author author = JsonConvert.DeserializeObject<Author>(responsestring);
        }

        public async Task UpdateAuthorAsync(int id, AuthorWithoutId author)
        {
            string json = JsonConvert.SerializeObject(author);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync($"Authors/{id}", content);
            string responseString = await response.Content.ReadAsStringAsync();
            Authors updatedBook = JsonConvert.DeserializeObject<Authors>(responseString);
        }
    }
}
