using System.Text.Json;
using Tesy.Programs;

namespace Tesy.Serializers
{
    class WeekProgramParams
    {
        public int Day { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public int Temp { get; set; }
        public string? Program_number { get; set; }
    }

    public class WeekProgramPayload
    {
        /// <summary>
        /// Serializes Add and Edit Week Program parameters as JSON string.
        /// </summary>
        /// <param name="weekProgram">Week Program parameters to serialize.</param>
        /// <param name="programKey">Week Program <c>program_number</c> parameter to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonPayload(CreateWeekProgram weekProgram, string programKey)
        {
            var @params = new WeekProgramParams
            {
                Day = weekProgram.DayOfWeek,
                From = weekProgram.FromTime,
                To = weekProgram.ToTime,
                Temp = weekProgram.ProgramTemp,
                Program_number = programKey
            };

            string payload = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}