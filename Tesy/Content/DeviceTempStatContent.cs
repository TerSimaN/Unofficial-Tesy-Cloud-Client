using System.Text.Json.Serialization;

namespace Tesy.Content
{
    public record class DeviceTempStatContent (
        [property: JsonPropertyName("data")] DataContent[] Data,
        [property: JsonPropertyName("period")] object[] Period
    );

    public record class DataContent (
        [property: JsonPropertyName("time")] int Time,
        [property: JsonPropertyName("real")] object Real,
        [property: JsonPropertyName("target")] object Target
    );
}