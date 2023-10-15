using System.Text.Json.Serialization;

public record class AppTimeResponseContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] string AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] AppTimeResponsePayloadContent Payload
);

public record class AppTimeResponsePayloadContent (
    [property: JsonPropertyName("day")] short Day,
    [property: JsonPropertyName("time")] string Time
);