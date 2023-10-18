using System.Text.Json.Serialization;

namespace Tesy.Content.MyDevices
{
    public record class DeviceTime (
        [property: JsonPropertyName("date")] string Date,
        [property: JsonPropertyName("time")] string Time
    );
}