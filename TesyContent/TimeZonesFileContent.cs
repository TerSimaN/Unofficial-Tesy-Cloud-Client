using System.Text.Json.Serialization;

public record class TimeZonesFileContent (
    [property: JsonPropertyName("countryCode")] string CountryCode,
    [property: JsonPropertyName("ianaId")] string IanaId,
    [property: JsonPropertyName("windowsId")] string WindowsId,
    [property: JsonPropertyName("utcOffset")] string UtcOffset,
    [property: JsonPropertyName("comments")] string Comments
);