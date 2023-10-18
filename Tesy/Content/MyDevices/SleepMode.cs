using System.Text.Json.Serialization;

namespace Tesy.Content.MyDevices
{
    public record class SleepMode (
        [property: JsonPropertyName("time")] int Time
    );
}