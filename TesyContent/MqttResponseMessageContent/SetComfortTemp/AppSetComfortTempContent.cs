using System.Text.Json.Serialization;

public record class AppSetComfortTempContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] string AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] AppSetComfortTempPayloadContent Payload
);

public record class AppSetComfortTempPayloadContent (
    [property: JsonPropertyName("temp")] short Temp
);