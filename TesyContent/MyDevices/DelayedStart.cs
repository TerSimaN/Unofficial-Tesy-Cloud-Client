using System.Text.Json.Serialization;

public record class DelayedStart (
    [property: JsonPropertyName("time")] int Time,
    [property: JsonPropertyName("temp")] short Temp
);