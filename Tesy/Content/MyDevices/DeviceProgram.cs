using System.Text.Json.Serialization;

namespace Tesy.Content.MyDevices
{
    public record class DeviceProgram (
        [property: JsonPropertyName("day")] short Day,
        [property: JsonPropertyName("from")] string From,
        [property: JsonPropertyName("to")] string To,
        [property: JsonPropertyName("temp")] short Temp,
        [property: JsonPropertyName("program_number")] object Program_Number
    );
}