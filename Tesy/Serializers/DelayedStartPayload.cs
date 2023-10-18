using System.Text.Json;

namespace Tesy.Serializers
{
    class DelayedStartParams
    {
        public int Time { get; set; }
        public short Temp { get; set; }
    }

    public class DelayedStartPayload
    {
        /// <summary>
        /// Serializes DelayedStart parameters as JSON string.
        /// </summary>
        /// <param name="time">DelayedStart <c>time</c> parameter to serialize.</param>
        /// <param name="temperature">DelayedStart <c>temp</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(int time, short temperature)
        {
            var @params = new DelayedStartParams
            {
                Time = time,
                Temp = temperature
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}