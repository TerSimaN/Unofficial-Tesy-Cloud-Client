using System.Text.Json.Serialization;

public record class SetTempStatisticPayloadContent (
    [property: JsonPropertyName("app_id")] short AppId,
    [property: JsonPropertyName("target")] short Target,
    [property: JsonPropertyName("timeRemaining")] short TimeRemaining,
    [property: JsonPropertyName("currentTemp")] float CurrentTemp,
    [property: JsonPropertyName("command")] string Command,
    [property: JsonPropertyName("heating")] string Heating
);