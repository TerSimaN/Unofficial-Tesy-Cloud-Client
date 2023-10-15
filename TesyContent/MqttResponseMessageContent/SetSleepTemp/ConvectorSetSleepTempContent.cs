using System.Text.Json.Serialization;

public record class ConvectorSetSleepTempContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] short AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] ConvectorSetSleepTempPayloadContent Payload
);

public record class ConvectorSetSleepTempPayloadContent (
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("app_id")] short AppId
);