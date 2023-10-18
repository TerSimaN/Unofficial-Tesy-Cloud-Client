using System.Text.Json.Serialization;

namespace Tesy.Content.MyDevices
{
    public record class EcoTemp (
        [property: JsonPropertyName("temp")] short Temp,
        [property: JsonPropertyName("time")] int Time
    );
}