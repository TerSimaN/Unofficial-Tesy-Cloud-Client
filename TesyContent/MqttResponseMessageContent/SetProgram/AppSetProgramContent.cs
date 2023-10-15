using System.Text.Json.Serialization;

public record class AppSetProgramContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] string AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] AppSetProgramPayloadContent Payload
);

public record class AppSetProgramPayloadContent (
    [property: JsonPropertyName("day")] short Day,
    [property: JsonPropertyName("from")] string From,
    [property: JsonPropertyName("to")] string To,
    [property: JsonPropertyName("temp")] short Temp,
    [property: JsonPropertyName("program_number")] string ProgramNumber
);