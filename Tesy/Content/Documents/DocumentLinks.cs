using System.Text.Json.Serialization;

namespace Tesy.Content.Documents
{
    public record class DocumentLinks (
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("link")] string Link
    );
}