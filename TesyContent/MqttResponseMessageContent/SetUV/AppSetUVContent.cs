using System.Text.Json.Serialization;

public record class AppSetUVContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] string AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] AppSetUVPayloadContent Payload
);

public record class AppSetUVPayloadContent (
    [property: JsonPropertyName("status")] string Status
);