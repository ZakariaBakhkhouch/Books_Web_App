using System.Text.Json.Serialization;

namespace BooksWebApp.Models
{
    public class Response
    {
        [JsonPropertyName("message")] public string? Message { get; set; }

        [JsonPropertyName("isAuthenticated")] public bool IsAuthenticated { get; set; }

        [JsonPropertyName("email")] public string? Email { get; set; }    

        [JsonPropertyName("roles")] public List<string>? Roles { get; set; }

        [JsonPropertyName("expirationOn")] public DateTime? ExpiresOn { get; set; }

        [JsonPropertyName("token")] public string? Token { get; set; }
    }
}
