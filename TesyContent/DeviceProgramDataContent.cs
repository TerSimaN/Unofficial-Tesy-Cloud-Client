using System.Text.Json.Serialization;

public record class DeviceProgramDataContent (
    [property: JsonPropertyName("programDay")] int ProgramDay,
    [property: JsonPropertyName("programFrom")] string ProgramFrom
);