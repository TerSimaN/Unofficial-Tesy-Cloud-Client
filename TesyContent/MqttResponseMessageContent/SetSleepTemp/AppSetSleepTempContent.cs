using System.Text.Json.Serialization;

public record class AppSetSleepTempContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] string AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] AppSetSleepTempPayloadContent Payload
);

public record class AppSetSleepTempPayloadContent (
    [property: JsonPropertyName("time")] short Time
);