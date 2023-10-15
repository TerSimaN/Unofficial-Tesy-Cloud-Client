using System.Text.Json.Serialization;

public record class DocumentLinks (
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("link")] string Link
);