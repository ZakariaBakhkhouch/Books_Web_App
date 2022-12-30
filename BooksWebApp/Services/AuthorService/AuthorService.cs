using BooksWebApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace BooksWebApp.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        static string baseURL = "https://localhost:44312/api/";

        //public AuthorService()
        //{
        //    _httpClient = new HttpClient { BaseAddress = new Uri("") };
        //    _httpClient.DefaultRequestHeaders.Accept.Clear();
        //    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    _httpClient.Timeout = TimeSpan.FromMinutes(6);
        //}

        public async Task<List<Authors>> GetAuthorsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                // Set the base address for the client
                client.BaseAddress = new Uri(baseURL);

                // Add default headers to the client
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Make a GET request to the API
                HttpResponseMessage response = await client.GetAsync("Authors");

                // Read the response as a string
                string responseString = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string into a list of Book objects
                List<Authors> authors = JsonConvert.DeserializeObject<List<Authors>>(responseString);

                return authors;
            }
        }

        public async Task<Author> GetAuthorAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                HttpResponseMessage response = await client.GetAsync($"Authors/{id}");

                string responseString = await response.Content.ReadAsStringAsync();

                Author author = JsonConvert.DeserializeObject<Author>(responseString);

                return author;
            }
        }

        public async Task AddAuthorAsync(AuthorWithoutId author)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);

                // Serialize the book object into a JSON string
                string json = JsonConvert.SerializeObject(author);

                // Create a StringContent object with the JSON string
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Make a POST request to the API
                HttpResponseMessage response = await client.PostAsync("Authors", content);

                // Read the response as a string
                string responseString = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string into a Book object
                Book addedBook = JsonConvert.DeserializeObject<Book>(responseString);
            }
        }

        public async Task DeleteBookByIdAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                await client.DeleteAsync($"authors/{id}");

                HttpResponseMessage response = await client.GetAsync($"authors/{id}");

                string responsestring = await response.Content.ReadAsStringAsync();

                Author author = JsonConvert.DeserializeObject<Author>(responsestring);
            }
        }

        public async Task UpdateBookAsync(int id, AuthorWithoutId author)
        {
            using (HttpClient client = new HttpClient())
            {
                // Serialize the book object into a JSON string
                string json = JsonConvert.SerializeObject(author);

                // Create a StringContent object with the JSON string
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Make a PUT request to the API
                client.BaseAddress = new Uri(baseURL);
                HttpResponseMessage response = await client.PutAsync($"Authors/{id}", content);

                // Read the response as a string
                string responseString = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string into a Book object
                Authors updatedBook = JsonConvert.DeserializeObject<Authors>(responseString);
            }
        }
    }
}
