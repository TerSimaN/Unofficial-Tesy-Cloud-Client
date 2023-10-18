using System.Text.Json.Serialization;

namespace Tesy.Content.MyDevices
{
    public record class DelayedStart (
        [property: JsonPropertyName("time")] int Time,
        [property: JsonPropertyName("temp")] short Temp
    );
}