
using System.Text.Json.Serialization;

namespace BooksWebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email is required")]
        [JsonPropertyName("email")] public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [JsonPropertyName("password")] public string? Password { get; set; }
    }
}
