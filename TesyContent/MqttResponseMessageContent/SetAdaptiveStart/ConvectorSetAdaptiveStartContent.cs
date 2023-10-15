using System.Text.Json.Serialization;

public record class ConvectorSetAdaptiveStartContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] short AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] ConvectorSetAdaptiveStartPayloadContent Payload
);

public record class ConvectorSetAdaptiveStartPayloadContent (
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("app_id")] short AppId
);