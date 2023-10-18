using System.Text.Json.Serialization;

namespace Tesy.Content.MyDevices
{
    public record class ComfortTemp (
        [property: JsonPropertyName("temp")] short Temp
    );
}