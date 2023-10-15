using System.Text.Json.Serialization;

public record class DeviceTime (
    [property: JsonPropertyName("date")] string Date,
    [property: JsonPropertyName("time")] string Time
);