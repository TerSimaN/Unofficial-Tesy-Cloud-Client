using System.Text.Json.Serialization;

public record class AppDeleteProgramContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] string AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] AppDeleteProgramPayloadContent Payload
);

public record class AppDeleteProgramPayloadContent (
    [property: JsonPropertyName("program_number")] string ProgramNumber
);