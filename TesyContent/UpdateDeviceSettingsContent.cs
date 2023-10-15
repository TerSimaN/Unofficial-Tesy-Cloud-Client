using System.Text.Json.Serialization;

public record class UpdateDeviceSettingsContent (
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("message")] string Message
);