using System.Text.Json.Serialization;

public record class UserInfoContent(
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("firstName")] string FirstName,
    [property: JsonPropertyName("lastName")] string LastName,
    [property: JsonPropertyName("lang")] string Language
);