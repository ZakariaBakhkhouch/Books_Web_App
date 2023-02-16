using System.Security.Policy;
using System.Text.Json.Serialization;

namespace BooksWebApp.Models
{
    public class Book
    {
        [JsonPropertyName("Id")] public int Id { get; set; }

        [JsonPropertyName("title")] public string? Title { get; set; }

        [JsonPropertyName("description")] public string? Description { get; set; }

        [JsonPropertyName("cover")] public byte[]? Cover { get; set; }

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

        [JsonPropertyName("rate")] public int? Rate { get; set; }

        [JsonPropertyName("genre")] public string? Genre { get; set; }

        [JsonPropertyName("cover")] public IFormFile? Cover { get; set; }

        [JsonPropertyName("dateAdded")] public DateTime? DateAdded { get; set; }

        [JsonPropertyName("publisherId")]  public int? PublisherId { get; set; }

        [JsonPropertyName("authors")] public List<int>? Authors { get; set; }
    }

    public class BookWithAuthorsWithCover
    {
        [JsonPropertyName("Id")] public int Id { get; set; }

        [JsonPropertyName("title")] public string? Title { get; set; }

        [JsonPropertyName("description")] public string? Description { get; set; }

        [JsonPropertyName("rate")] public int? Rate { get; set; }

        [JsonPropertyName("genre")] public string? Genre { get; set; }

        [JsonPropertyName("cover")] public byte[]? Cover { get; set; }

        [JsonPropertyName("dateAdded")] public DateTime? DateAdded { get; set; }

        [JsonPropertyName("publisherId")] public int? PublisherId { get; set; }

        [JsonPropertyName("authors")] public List<int>? Authors { get; set; }
    }
}
