using System.Text.Json.Serialization;

public record class ConvectorWifiInfoContent (
	[property: JsonPropertyName("code")] short Code,
	[property: JsonPropertyName("message")] string Message,
	[property: JsonPropertyName("app_id")] short AppId,
	[property: JsonPropertyName("command")] string Command,
	[property: JsonPropertyName("payload")] ConvectorWifiInfoPayloadContent Payload
);

public record class ConvectorWifiInfoPayloadContent (
    [property: JsonPropertyName("wifiinfo")] string WifiInfo,
    [property: JsonPropertyName("app_id")] short AppId
);