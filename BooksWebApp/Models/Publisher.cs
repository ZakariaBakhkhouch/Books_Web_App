using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BooksWebApp.Models
{
    public class Publisher
    {
        [Required]
        [JsonPropertyName("id")] public int Id { get; set; }

        [Required]
        [JsonPropertyName("fullName")] public string FullName { get; set; }
    }
    
    public class PublisherWithoutId
    {
        [JsonPropertyName("fullName")] public string FullName { get; set; }
    }

    public class PublisherWithBooksAndAuthorsVM
    {
        [JsonPropertyName("fullName")] public string? FullName { get; set; }

        [JsonPropertyName("books")] public List<BookAuthorVM>? Books { get; set; }
    }

    public class BookAuthorVM
    {
        [JsonPropertyName("bookName")] public string? BookName { get; set; }

        [JsonPropertyName("bookAuthors")] public List<string>? BookAuthors { get; set; }
    }
}
