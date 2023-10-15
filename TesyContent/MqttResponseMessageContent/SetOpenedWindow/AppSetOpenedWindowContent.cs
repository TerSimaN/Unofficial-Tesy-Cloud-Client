using System.Text.Json.Serialization;

public record class AppSetOpenedWindowContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] string AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] AppSetOpenedWindowPayloadContent Payload
);

public record class AppSetOpenedWindowPayloadContent (
    [property: JsonPropertyName("status")] string Status
);