using System.Text.Json.Serialization;

public record class ConvectorSetDelayedStartContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] short AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] ConvectorSetDelayedStartPayloadContent Payload
);

public record class ConvectorSetDelayedStartPayloadContent (
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("time")] short Time,
    [property: JsonPropertyName("app_id")] short AppId
);