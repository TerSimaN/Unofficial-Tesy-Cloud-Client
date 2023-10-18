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
        private readonly JsonSerializerOptions serializerOptions = new() {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public string SerializeWeekProgramParamsAsJsonPayload(CreateWeekProgram weekProgram, string programKey)
        {
            var @params = new WeekProgramParams
            {
                Day = weekProgram.DayOfWeek,
                From = weekProgram.FromTime,
                To = weekProgram.ToTime,
                Temp = weekProgram.ProgramTemp,
                Program_number = programKey
            };

            string payload = JsonSerializer.Serialize(@params, serializerOptions);
            Console.WriteLine(payload);

            return payload;
        }
    }
}