using System.Text.Json.Serialization;

public record class ConvectorSetUVContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] short AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] ConvectorSetUVPayloadContent Payload
);

public record class ConvectorSetUVPayloadContent (
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("app_id")] short AppId
);