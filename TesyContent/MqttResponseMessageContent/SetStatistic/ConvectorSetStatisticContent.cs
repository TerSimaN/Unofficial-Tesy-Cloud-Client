using System.Text.Json.Serialization;

public record class ConvectorSetStatisticContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] short AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] ConvectorSetStatisticPayloadContent Payload
);

public record class ConvectorSetStatisticPayloadContent (
    [property: JsonPropertyName("app_id")] short AppId,
    [property: JsonPropertyName("target")] short Target,
    [property: JsonPropertyName("timeRemaining")] short TimeRemaining,
    [property: JsonPropertyName("currentTemp")] float CurrentTemp,
    [property: JsonPropertyName("from")] string From,
    [property: JsonPropertyName("to")] string To,
    [property: JsonPropertyName("time")] short Time,
    [property: JsonPropertyName("command")] string Command
);