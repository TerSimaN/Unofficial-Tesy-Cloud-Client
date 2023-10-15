using System.Text.Json.Serialization;

public record class AppSetEcoTempContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] string AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] AppSetEcoTempPayloadContent Payload
);

public record class AppSetEcoTempPayloadContent (
    [property: JsonPropertyName("temp")] short Temp,
    [property: JsonPropertyName("time")] short Time
);