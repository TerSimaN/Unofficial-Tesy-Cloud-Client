using System.Text.Json.Serialization;

public record class Models (
    [property: JsonPropertyName("modelName")] string ModelName,
    [property: JsonPropertyName("modelImage")] string ModelImage,
    [property: JsonPropertyName("documents")] ModelDocuments Documents
);