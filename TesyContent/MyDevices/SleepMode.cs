using System.Text.Json.Serialization;

public record class SleepMode (
    [property: JsonPropertyName("time")] int Time
);