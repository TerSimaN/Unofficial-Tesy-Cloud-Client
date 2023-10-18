using System.Text.Json;

namespace Tesy.Serializers
{
    class TimeZoneParams
    {
        public short Day { get; set; }
        public string? Time { get; set; }
    }

    public class TimeZonePayload
    {
        /// <summary>
        /// Serializes TimeZone parameters as JSON string.
        /// </summary>
        /// <param name="day">TimeZone <c>day</c> parameter to serialize.</param>
        /// <param name="time">TimeZone <c>time</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(short day, string time)
        {
            var @params = new TimeZoneParams
            {
                Day = day,
                Time = time
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}