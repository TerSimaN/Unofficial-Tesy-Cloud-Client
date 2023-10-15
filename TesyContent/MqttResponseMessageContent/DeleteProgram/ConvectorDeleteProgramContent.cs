using System.Text.Json.Serialization;

public record class ConvectorDeleteProgramContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] short AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] ConvectorDeleteProgramPayloadContent Payload
);

public record class ConvectorDeleteProgramPayloadContent (
    [property: JsonPropertyName("program_number")] short ProgramNumber,
    [property: JsonPropertyName("app_id")] short AppId
);