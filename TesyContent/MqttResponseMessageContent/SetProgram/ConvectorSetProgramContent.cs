using System.Text.Json.Serialization;

public record class ConvectorSetProgramContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] short AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] ConvectorSetProgramPayloadContent Payload
);

public record class ConvectorSetProgramPayloadContent (
    [property: JsonPropertyName("day")] short Day,
    [property: JsonPropertyName("from")] string From,
    [property: JsonPropertyName("to")] string To,
    [property: JsonPropertyName("temp")] short Temp,
    [property: JsonPropertyName("program_number")] short ProgramNumber,
    [property: JsonPropertyName("app_id")] short AppId
);