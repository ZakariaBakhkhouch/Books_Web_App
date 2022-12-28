using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BooksWebApp.Models
{
    public class Author
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("fullName")] public string FullName { get; set; }
        [JsonProperty("bookTitles")] public List<string> BooksTitles { get; set; }
    }

    public class Authors
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("fullName")] public string FullName { get; set; }
    }
}
