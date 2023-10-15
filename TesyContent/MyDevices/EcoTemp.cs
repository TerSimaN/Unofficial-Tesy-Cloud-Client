using System.Text.Json.Serialization;

public record class EcoTemp (
    [property: JsonPropertyName("temp")] short Temp,
    [property: JsonPropertyName("time")] int Time
);