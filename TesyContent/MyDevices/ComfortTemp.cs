using System.Text.Json.Serialization;

public record class ComfortTemp (
    [property: JsonPropertyName("temp")] short Temp
);