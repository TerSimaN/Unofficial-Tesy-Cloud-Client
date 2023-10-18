using System.Text.Json.Serialization;

namespace Tesy.Content
{
    public record class UpdateDeviceSettingsContent (
        [property: JsonPropertyName("success")] bool Success,
        [property: JsonPropertyName("message")] string Message
    );
}