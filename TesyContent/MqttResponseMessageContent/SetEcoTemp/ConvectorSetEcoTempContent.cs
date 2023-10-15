using System.Text.Json.Serialization;

public record class ConvectorSetEcoTempContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] short AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] ConvectorSetEcoTempPayloadContent Payload
);

public record class ConvectorSetEcoTempPayloadContent (
    [property: JsonPropertyName("temp")] short Temp,
    [property: JsonPropertyName("time")] short Time,
    [property: JsonPropertyName("app_id")] short AppId
);