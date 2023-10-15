using System.Text.Json.Serialization;

public record class ConvectorSetAntiFrostContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] short AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] ConvectorSetAntiFrostPayloadContent Payload
);

public record class ConvectorSetAntiFrostPayloadContent (
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("app_id")] short AppId
);