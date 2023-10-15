using System.Text.Json.Serialization;

public record class LoginContent (
    [property: JsonPropertyName("userID")] int UserID,
    [property: JsonPropertyName("password")] string Password,
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("firstName")] string FirstName,
    [property: JsonPropertyName("lastName")] string LastName,
    [property: JsonPropertyName("lang")] string Language,
    [property: JsonPropertyName("debug_menu")] string DebugMenu,
    [property: JsonPropertyName("token")] string Token
);