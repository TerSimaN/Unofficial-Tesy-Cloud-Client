using System.Text.Json.Serialization;

public record class CredentialsContent (
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("password")] string Password
);