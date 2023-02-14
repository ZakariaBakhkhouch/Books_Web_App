
using System.Text.Json.Serialization;

namespace BooksWebApp.Models
{
    public class Register
    {
        [Required]
        [StringLength(100)]
        [JsonPropertyName("firstName")] public string? FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [JsonPropertyName("lastName")] public string? LastName { get; set; }

        [Required]
        [StringLength(50)]
        [JsonPropertyName("userName")] public string? Username { get; set; }

        [Required]
        [StringLength(128)]
        [JsonPropertyName("email")] public string? Email { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [JsonPropertyName("password")] public string? Password { get; set; }
    }
}
