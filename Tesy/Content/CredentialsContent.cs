using System.Text.Json.Serialization;

namespace Tesy.Content
{
    public record class CredentialsContent (
        [property: JsonPropertyName("email")] string Email,
        [property: JsonPropertyName("password")] string Password
    );
}