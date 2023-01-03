
namespace BooksWebApp.Services.BookService
{
    public class BookService : IBookService
    {
        static string baseURL = "https://localhost:44312/api/";
        private readonly HttpClient _client;

        public BookService(HttpClient client)
        {
            _client= client;
            _client = new HttpClient { BaseAddress = new Uri(baseURL) };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.Timeout = TimeSpan.FromMinutes(6);
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("Books");
            string responseString = await response.Content.ReadAsStringAsync();
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(responseString);
            return books;
        }

        public async Task<BookWithAuthors> GetBookAsync(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"Books/{id}");
            string responseString = await response.Content.ReadAsStringAsync();
            BookWithAuthors book = JsonConvert.DeserializeObject<BookWithAuthors>(responseString);
            return book;
        }

        public async Task AddBookAsync(BookWithAuthors book)
        {
            string json = JsonConvert.SerializeObject(book);
            // Create a StringContent object with the JSON string
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("Books", content);
            string responseString = await response.Content.ReadAsStringAsync();
            BookWithAuthors addedBook = JsonConvert.DeserializeObject<BookWithAuthors>(responseString);
        }

        public async Task UpdateBookAsync(int id, BookWithAuthors book)
        {
            string json = JsonConvert.SerializeObject(book);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync($"Books/{id}", content);
        }

        public async Task DeleteBookByIdAsync(int id)
        {
            await _client.DeleteAsync($"Books/{id}");

        }

    }
}
