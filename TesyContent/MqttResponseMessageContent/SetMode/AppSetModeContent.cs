using System.Text.Json.Serialization;

public record class AppSetModeContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] string AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] AppSetModePayloadContent Payload
);

public record class AppSetModePayloadContent (
    [property: JsonPropertyName("name")] string Name
);