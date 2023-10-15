using System.Text.Json.Serialization;

public record class AppSetTCorrectionContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] string AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] AppSetTCorrectionPayloadContent Payload
);

public record class AppSetTCorrectionPayloadContent (
    [property: JsonPropertyName("temp")] short Temp
);