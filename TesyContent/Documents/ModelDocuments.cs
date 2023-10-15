using System.Text.Json.Serialization;

public record class ModelDocuments (
    [property: JsonPropertyName("links")] Dictionary<string, DocumentLinks> Links
);