using System.Text.Json.Serialization;

namespace Tesy.Content.Documents
{
    public record class ModelDocuments (
        [property: JsonPropertyName("links")] Dictionary<string, DocumentLinks> Links
    );
}