using System.Text.Json.Serialization;

public record class AppSetAdaptiveStartContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] string AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] AppSetAdaptiveStartPayloadContent Payload
);

public record class AppSetAdaptiveStartPayloadContent (
    [property: JsonPropertyName("status")] string Status
);