public class CreateProgram
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

    private readonly TesyHttpClass tesyHttpClass;

    public CreateProgram(TesyHttpClass tesyHttpClass)
    {
        this.tesyHttpClass = tesyHttpClass;
    }

    /// <summary>
    /// Checks if values of <c>FromTime</c> and <c>ToTime</c> of new week program are valid.
    /// </summary>
    /// <returns><c>true</c> if values of <c>FromTime</c> and <c>ToTime</c> are valid, otherwise <c>false</c>.</returns>
    public bool IsTimeValid()
    {
        int timeFrom = ConvertTimeToMinutes(FromTime);
        int timeTo = ConvertTimeToMinutes(ToTime);
        bool isValid = true;

        if (!IsTimeToLessThanOrEqualTimeFrom(timeTo, timeFrom))
        {
            isValid = false;
        }

        if (!IsTimeGreaterThanProgramFromAndLessThanProgramTo(timeFrom, dayOfWeek))
        {
            isValid = false;
        }

        if (!IsTimeGreaterThanProgramFromAndLessThanProgramTo(timeTo, dayOfWeek))
        {
            isValid = false;
        }

        if (!IsTimeFromLessThanOrEqualProgramFromAndProgramToLessThanOrEqualTimeTo(timeFrom, timeTo, dayOfWeek))
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
        bool isValid = true;
        if (timeTo <= timeFrom)
        {
            Console.WriteLine("Error! \"from\" time must be before \"to\" time!");
            isValid = false;
        }

        return isValid;
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
    private bool IsTimeGreaterThanProgramFromAndLessThanProgramTo(int time, int day)
    {
        bool isValid = true;
        foreach (var program in tesyHttpClass.DeviceProgramsDictionary)
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
                    isValid = false;
                    break;
                }
            }
        }

        return isValid;
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
    private bool IsTimeFromLessThanOrEqualProgramFromAndProgramToLessThanOrEqualTimeTo(int timeFrom, int timeTo, int day)
    {
        bool isValid = true;
        foreach (var program in tesyHttpClass.DeviceProgramsDictionary)
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
                    isValid = false;
                    break;
                }
            }
        }

        return isValid;
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
        DayOfWeek = 0;
        FromTime = "";
        ToTime = "";
        ProgramTemp = 10;
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