using System.Text.Json.Serialization;

public record class AppSetAntiFrostContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] string AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] AppSetAntiFrostPayloadContent Payload
);

public record class AppSetAntiFrostPayloadContent (
    [property: JsonPropertyName("status")] string Status
);