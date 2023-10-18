using System.Text.Json.Serialization;

namespace Tesy.Content
{
    public record class DeviceProgramDataContent (
        [property: JsonPropertyName("programDay")] int ProgramDay,
        [property: JsonPropertyName("programFrom")] string ProgramFrom
    );
}