using System.Security.Policy;
using System.Text.Json.Serialization;

namespace BooksWebApp.Models
{
    public class Book
    {
        [JsonPropertyName("Id")] public int Id { get; set; }

        [JsonPropertyName("title")] public string? Title { get; set; }

        [JsonPropertyName("description")] public string? Description { get; set; }

        [JsonPropertyName("isRead")] public bool? IsRead { get; set; }

        [JsonPropertyName("dateRead")] public DateTime? DateRead { get; set; }

        [JsonPropertyName("rate")] public int? Rate { get; set; }

        [JsonPropertyName("genre")] public string? Genre { get; set; }

        [JsonPropertyName("coverURL")] public string? CoverUrl { get; set; }

        [JsonPropertyName("dateAdded")] public DateTime? DateAdded { get; set; }

        [JsonPropertyName("publisherId")]  public int? PublisherId { get; set; }

    }
    
    public class BookWithAuthors
    {
        [JsonPropertyName("Id")] public int Id { get; set; }

        [JsonPropertyName("title")] public string? Title { get; set; }

        [JsonPropertyName("description")] public string? Description { get; set; }

        [JsonPropertyName("isRead")] public bool? IsRead { get; set; }

        [JsonPropertyName("dateRead")] public DateTime? DateRead { get; set; }

        [JsonPropertyName("rate")] public int? Rate { get; set; }

        [JsonPropertyName("genre")] public string? Genre { get; set; }

        [JsonPropertyName("coverURL")] public string? CoverUrl { get; set; }

        [JsonPropertyName("dateAdded")] public DateTime? DateAdded { get; set; }

        [JsonPropertyName("publisherId")]  public int? PublisherId { get; set; }

        [JsonPropertyName("authors")] public List<int> Authors { get; set; }
    }
}
