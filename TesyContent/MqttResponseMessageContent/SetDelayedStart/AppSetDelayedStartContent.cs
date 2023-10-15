using System.Text.Json.Serialization;

public record class AppSetDelayedStartContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] string AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] AppSetDelayedStartPayloadContent Payload
);

public record class AppSetDelayedStartPayloadContent (
    [property: JsonPropertyName("time")] short Time,
    [property: JsonPropertyName("temp")] short Temp
);