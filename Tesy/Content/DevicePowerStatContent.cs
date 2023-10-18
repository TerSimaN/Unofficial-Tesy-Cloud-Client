using System.Text.Json.Serialization;

namespace Tesy.Content
{
    public record class DevicePowerStatContent (
        [property: JsonPropertyName("sub_label")] string SubLabel,
        [property: JsonPropertyName("main_label")] string MainLabel,
        [property: JsonPropertyName("consumption")] int Consumption,
        [property: JsonPropertyName("working_time")] object WorkingTime
    );
}