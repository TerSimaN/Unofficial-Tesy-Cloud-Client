using Tesy.Commands;

namespace Tesy.Programs
{
    public class CreateWeekProgram
    {
        private int dayOfWeek = 0;
        private short programTemp = 10;

        /// <summary>
        /// <c>"from"</c> time value of new week program.
        /// </summary>
        private string fromTime = "00:00";
        /// <summary>
        /// <c>"to"</c> time value of new week program.
        /// </summary>
        private string toTime = "00:00";

        private readonly MyDevices myDevices;

        public CreateWeekProgram(MyDevices myDevices)
        {
            this.myDevices = myDevices;
        }

        /// <summary>
        /// Reads <c>dayOfWeek</c>, 
        /// <c>fromTime</c>, 
        /// <c>toTime</c> 
        /// and <c>programTemp</c> values for new week program from the Console.
        /// </summary>
        public void ReadCreateProgramValues()
        {
            dayOfWeek = ReadDayOfWeekFromConsole();
            fromTime = ReadFromTimeFromConsole();
            toTime = ReadToTimeFromConsole();
            programTemp = ReadTemperatureFromConsole();
        }

        /// <summary>
        /// Reads <c>fromTime</c>, 
        /// <c>toTime</c> 
        /// and <c>programTemp</c> values for existing week program from the Console.
        /// </summary>
        public void ReadEditProgramValues()
        {
            fromTime = ReadFromTimeFromConsole();
            toTime = ReadToTimeFromConsole();
            programTemp = ReadTemperatureFromConsole();
        }

        /// <summary>
        /// Reads a <c>dayOfWeek</c> value from the Console.
        /// </summary>
        /// <returns>The read <c>dayOfWeek</c>.</returns>
        private int ReadDayOfWeekFromConsole()
        {
            int dayOfWeek = 0;
            do
            {
                Console.Write("Enter number of day [Monday - 0, Tuesday - 1, Wednesday - 2, Thursday - 3, Friday - 4, Saturday - 5, Sunday - 6]: ");
                var inputValue = Console.ReadLine();

                if ((inputValue != null) && (inputValue != ""))
                {
                    dayOfWeek = int.Parse(inputValue);
                }
            } while ((dayOfWeek < 0) || (dayOfWeek > 6));

            return dayOfWeek;
        }

        /// <summary>
        /// Reads a <c>fromTime</c> value from the Console.
        /// </summary>
        /// <returns>The read <c>fromTime</c>.</returns>
        private string ReadFromTimeFromConsole()
        {
            int fromTimeInHours = 0;
            int fromTimeInMinutes = 0;
            do
            {
                Console.Write("Enter \"from\" time in hours: ");
                var inputValue = Console.ReadLine();

                if ((inputValue != null) && (inputValue != ""))
                {
                    fromTimeInHours = int.Parse(inputValue);
                }
            } while ((fromTimeInHours < 0) || (fromTimeInHours > 23));

            do
            {
                Console.Write("Enter \"from\" time in minutes: ");
                var inputValue = Console.ReadLine();

                if ((inputValue != null) && (inputValue != ""))
                {
                    fromTimeInMinutes = int.Parse(inputValue);
                }
            } while ((fromTimeInMinutes < 0) || (fromTimeInMinutes > 59));

            string fromTime = CombineHoursAndMinutes(fromTimeInHours, fromTimeInMinutes);
            return fromTime;
        }

        /// <summary>
        /// Reads a <c>toTime</c> value from the Console.
        /// </summary>
        /// <returns>The read <c>toTime</c>.</returns>
        private string ReadToTimeFromConsole()
        {
            int toTimeInHours = 0;
            int toTimeInMinutes = 0;
            do
            {
                Console.Write("Enter \"to\" time in hours: ");
                var inputValue = Console.ReadLine();

                if ((inputValue != null) && (inputValue != ""))
                {
                    toTimeInHours = int.Parse(inputValue);
                }
            } while ((toTimeInHours < 0) || (toTimeInHours > 23));

            do
            {
                Console.Write("Enter \"to\" time in minutes: ");
                var inputValue = Console.ReadLine();

                if ((inputValue != null) && (inputValue != ""))
                {
                    toTimeInMinutes = int.Parse(inputValue);
                }
            } while ((toTimeInMinutes < 0) || (toTimeInMinutes > 59));

            string toTime = CombineHoursAndMinutes(toTimeInHours, toTimeInMinutes);
            return toTime;
        }

        /// <summary>
        /// Reads <c>newTemperature</c> value from the Console.
        /// </summary>
        /// <returns>The read <c>temperature</c>.</returns>
        private short ReadTemperatureFromConsole()
        {
            short temperature = 0;
            do
            {
                Console.Write("Enter temperature [10, 30]: ");
                var inputValue = Console.ReadLine();

                if ((inputValue != null) && (inputValue != ""))
                {
                    temperature = short.Parse(inputValue);
                }
            } while ((temperature < 10) || (temperature > 30));

            return temperature;
        }

        /// <summary>
        /// Combines <c>hours</c> and <c>minutes</c> values into one string value.
        /// </summary>
        /// <param name="hours">Value of <c>hours</c>.</param>
        /// <param name="minutes">Value of <c>minutes</c>.</param>
        /// <returns>A <c>time</c> string containing values of
        /// <c>hours</c> and <c>minutes</c>.</returns>
        private string CombineHoursAndMinutes(int hours, int minutes)
        {
            string time = "";
            time += (hours < 10) ? $"0{hours}" : $"{hours}";
            time += ":";
            time += (minutes < 10) ? $"0{minutes}" : $"{minutes}";

            return time;
        }

        /// <summary>
        /// Checks if values of <c>FromTime</c> and <c>ToTime</c> of new week program are valid.
        /// </summary>
        /// <returns><c>true</c> if values of <c>FromTime</c> and <c>ToTime</c> are valid, otherwise <c>false</c>.</returns>
        public async Task<bool> IsTimeValid()
        {
            int timeFrom = ConvertTimeToMinutes(FromTime);
            int timeTo = ConvertTimeToMinutes(ToTime);
            bool isValid = true;

            if (!IsTimeToLessThanOrEqualTimeFrom(timeTo, timeFrom))
            {
                isValid = false;
            }

            if (!await IsTimeGreaterThanProgramFromAndLessThanProgramTo(timeFrom, dayOfWeek))
            {
                isValid = false;
            }

            if (!await IsTimeGreaterThanProgramFromAndLessThanProgramTo(timeTo, dayOfWeek))
            {
                isValid = false;
            }

            if (!await IsTimeFromLessThanOrEqualProgramFromAndProgramToLessThanOrEqualTimeTo(timeFrom, timeTo, dayOfWeek))
            {
                isValid = false;
            }

            if (!isValid)
            {
                ResetNewWeekProgramParams();
            }

            return isValid;
        }

        /// <summary>
        /// Checks if <c>timeTo</c> is less than or equal to <c>timeFrom</c>.
        /// </summary>
        /// <param name="timeTo">Value of <c>timeTo</c>.</param>
        /// <param name="timeFrom">Value of <c>timeFrom</c>.</param>
        /// <returns><c>true</c> if <c>timeTo</c> is after <c>timeFrom</c>, otherwise <c>false</c>.</returns>
        private bool IsTimeToLessThanOrEqualTimeFrom(int timeTo, int timeFrom)
        {
            if (timeTo <= timeFrom)
            {
                Console.WriteLine("Error! \"from\" time must be before \"to\" time!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if <c>time</c> is greater than <c>programFrom</c> 
        /// and less than <c>programTo</c> 
        /// for <c>programDay</c> equal to <c>day</c>.
        /// </summary>
        /// <param name="time">Value of <c>time</c> to check.</param>
        /// <param name="day">Value of <c>day</c> to compare <c>programDay</c> to.</param>
        /// <returns>
        /// <c>true</c> if <c>time</c> is greater than <c>programFrom</c> 
        /// and less than <c>programTo</c>, otherwise <c>false</c>.
        /// </returns>
        private async Task<bool> IsTimeGreaterThanProgramFromAndLessThanProgramTo(int time, int day)
        {
            var devicePrograms = await myDevices.GetDevicePrograms();
            foreach (var program in devicePrograms)
            {
                string programFrom = program.Value.From;
                string programTo = program.Value.To;
                int programDay = program.Value.Day;

                if (programDay == day)
                {
                    int programFromInMinutes = ConvertTimeToMinutes(programFrom);
                    int programToInMinutes = ConvertTimeToMinutes(programTo);
                    
                    /* Checks if given "time" value is between program "from" time value 
                    and program "to" time value 
                    for program "day" value equal to given "day" value
                    For example:
                    param "day" = 0
                    param "time" = "00:01"
                    program "day": 0
                    program "frpm": "00:00"
                    program "to": "06:00"
                    if (param "day" == program "day")
                    then if ("00:01" > "00:00" && "00:01" < "06:00") then isValid = false */                
                    if ((time > programFromInMinutes) && (time < programToInMinutes))
                    {
                        Console.WriteLine($"Error! \"from\" time and/or \"to\" time values cannot be between {programFrom} and {programTo}!");
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if <c>timeFrom</c> is less than or equal to <c>programFrom</c> 
        /// <para>and if <c>programTo</c> is less than or equal to <c>timeTo</c></para> 
        /// for <c>programDay</c> equal to <c>day</c>
        /// </summary>
        /// <param name="timeFrom">Value of <c>timeFrom</c> to check.</param>
        /// <param name="timeTo">Value of <c>timeTo</c> to check.</param>
        /// <param name="day">Value of <c>day</c> to compare <c>programDay</c> to.</param>
        /// <returns>
        /// <c>true</c> if <c>timeFrom</c> is greater than <c>programFrom</c>
        /// and if <c>timeTo</c> is less than <c>programTo</c>, otherwise <c>false</c>.
        /// </returns>
        private async Task<bool> IsTimeFromLessThanOrEqualProgramFromAndProgramToLessThanOrEqualTimeTo(int timeFrom, int timeTo, int day)
        {
            var devicePrograms = await myDevices.GetDevicePrograms();
            foreach (var program in devicePrograms)
            {
                string programFrom = program.Value.From;
                string programTo = program.Value.To;
                int programDay = program.Value.Day;

                if (programDay == day)
                {
                    int programFromInMinutes = ConvertTimeToMinutes(programFrom);
                    int programToInMinutes = ConvertTimeToMinutes(programTo);

                    /* Checks if given "timeFrom" value is before or equal to program "from" time value 
                    and if given "timeTo" value is after or equal to program "to" time value
                    for program "day" value equal to given "day" value
                    For example:
                    param "day" = 0
                    param "timeFrom" = "00:00"
                    param "timeTo" = "06:01"
                    program "day": 0
                    program "from": "00:00"
                    program "to": "06:00"
                    if (param "day" == program "day")
                    then if ("00:00" <= "00:00" && "06:00" <= "06:01") then isValid = false */
                    if ((timeFrom <= programFromInMinutes) && (programToInMinutes <= timeTo))
                    {
                        Console.WriteLine(
                            $"Error! \"from\" time value cannot be less than or equal to {programFrom} " + 
                            $"and \"to\" time value cannot be greater than or equal to {programTo}"
                        );
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Converts the given <c>time</c> string into minutes.
        /// </summary>
        /// <param name="timeToConvert">The <c>time</c> string to convert.</param>
        /// <returns><c>minutes</c> value containing hours and minutes values from the <c>time</c> string.</returns>
        private int ConvertTimeToMinutes(string timeToConvert)
        {
            string[] time = timeToConvert.Split(":");
            int hours = int.Parse(time[0]);
            int minutes = int.Parse(time[1]);

            return hours * 60 + minutes;
        }

        /// <summary>
        /// Sets Week Program values their to default values.
        /// </summary>
        private void ResetNewWeekProgramParams()
        {
            dayOfWeek = 0;
            fromTime = "00:00";
            toTime = "00:00";
            programTemp = 10;
        }

        public int DayOfWeek
        {
            get { return dayOfWeek; }
            set { dayOfWeek = value; }
        }

        public short ProgramTemp
        {
            get { return programTemp; }
            set { programTemp = value; }
        }

        public string FromTime
        {
            get { return fromTime; }
            set { fromTime = value; }
        }

        public string ToTime
        {
            get { return toTime; }
            set { toTime = value; }
        }
    }
}