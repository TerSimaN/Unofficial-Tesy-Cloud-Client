using Tesy.Content;

public static class Input
{
    private static readonly Dictionary<string, string> languages = TesyConstants.Languages;

    /// <summary>
    /// Combines <c>hours</c> and <c>minutes</c> values into one string value.
    /// </summary>
    /// <param name="hours">Value of <c>hours</c>.</param>
    /// <param name="minutes">Value of <c>minutes</c>.</param>
    /// <returns>A <c>time</c> string containing values of
    /// <c>hours</c> and <c>minutes</c>.</returns>
    private static string CombineHoursAndMinutes(int hours, int minutes)
    {
        string time = "";
        time += (hours < 10) ? $"0{hours}" : $"{hours}";
        time += ":";
        time += (minutes < 10) ? $"0{minutes}" : $"{minutes}";

        return time;
    }

    /// <summary>
    /// Reads <c>email</c> value from the Console.
    /// </summary>
    /// <returns>The read <c>email</c>.</returns>
    public static string ReadEmailFromConsole()
    {
        string email = "";
        do
        {
            Console.Write("Please enter a valid email: ");
            var inputValue = Console.ReadLine();

            if (inputValue != null)
            {
                email = inputValue.Trim();
            }
        } while (email.Length < 1);

        return email;
    }

    /// <summary>
    /// Reads <c>password</c> value from the Console.
    /// </summary>
    /// <returns>The read <c>password</c>.</returns>
    public static string ReadPasswordFromConsole()
    {
        string password = "";
        do
        {
            Console.Write("Please enter a valid password: ");
            var inputValue = Console.ReadLine();

            if (inputValue != null)
            {
                password = inputValue.Trim();
            }
        } while (password.Length < 1);

        return password;
    }

    /// <summary>
    /// Reads <c>firstName</c> value from the Console.
    /// </summary>
    /// <returns>The read <c>firstName</c>.</returns>
    public static string ReadFirstNameFromConsole()
    {
        string firstName = "";
        do
        {
            Console.Write("Enter a value for first name: ");
            var inputValue = Console.ReadLine();

            if (inputValue != null)
            {
                firstName = inputValue.Trim();
            }
        } while (firstName.Length < 1);

        return firstName;
    }

    /// <summary>
    /// Reads <c>lastName</c> value from the Console.
    /// </summary>
    /// <returns>The read <c>lastName</c>.</returns>
    public static string ReadLastNameFromConsole()
    {
        string lastName = "";
        do
        {
            Console.Write("Enter a value for last name: ");
            var inputValue = Console.ReadLine();

            if (inputValue != null)
            {
                lastName = inputValue.Trim();
            }
        } while (lastName.Length < 1);

        return lastName;
    }

    /// <summary>
    /// Reads <c>language</c> value from the Console.
    /// </summary>
    /// <returns>The read <c>language</c>.</returns>
    public static string ReadLanguageFromConsole()
    {
        string language = "";
        do
        {
            Output.PrintAvailableLanguages(languages);
            Console.Write("Enter a value for language: ");
            var inputValue = Console.ReadLine();

            if ((inputValue != null) && languages.ContainsKey(inputValue.Trim()))
            {
                language = languages[inputValue];
            }
        } while (language.Length < 1);

        return language;
    }

    /// <summary>
    /// Reads <c>newPassword</c> value from the Console.
    /// </summary>
    /// <returns>The read <c>newPassword</c>.</returns>
    public static string ReadNewPasswordFromConsole()
    {
        string newPassword = "";
        do
        {
            Console.Write("Enter a new password: ");
            var inputValue = Console.ReadLine();

            if (inputValue != null)
            {
                newPassword = inputValue.Trim();
            }
        } while (newPassword.Length < 1);
        
        return newPassword;
    }

    /// <summary>
    /// Reads <c>confirmPassword</c> value from the Console.
    /// </summary>
    /// <returns>The read <c>confirmPassword</c>.</returns>
    public static string ReadConfirmNewPasswordFromConsole()
    {
        string confirmPassword = "";
        do
        {
            Console.Write("Confirm password: ");
            var inputValue = Console.ReadLine();

            if (inputValue != null)
            {
                confirmPassword = inputValue.Trim();
            }
        } while (confirmPassword.Length < 1);

        return confirmPassword;
    }

    /// <summary>
    /// Reads DeviceTempStat or DevicePowerStat <c>activity</c> value from Console.
    /// </summary>
    /// <returns>The read <c>activity</c>.</returns>
    public static string ReadActivityFromConsole()
    {
        string activity = "";
        string[] activities = {"daily", "monthly", "annual"};
        do
        {
            Console.Write("Enter activity [daily, monthly, annual]: ");
            var inputValue = Console.ReadLine();

            if ((inputValue != null) && activities.Contains(inputValue))
            {
                activity = inputValue.Trim();
            }
        } while (activity.Length < 1);

        return activity;
    }

    /// <summary>
    /// Reads <c>dayOfWeek</c>, 
    /// <c>fromTime</c>, 
    /// <c>toTime</c> 
    /// and <c>temperature</c> values for new week program from the Console.
    /// </summary>
    /// <param name="createProgram">The week program to assign the read values to.</param>
    public static void ReadCreateProgramValuesFromConsole(CreateProgram createProgram)
    {
        createProgram.DayOfWeek = ReadDayOfWeekFromConsole();
        createProgram.FromTime = ReadFromTimeFromConsole();
        createProgram.ToTime = ReadToTimeFromConsole();
        createProgram.ProgramTemp = ReadTemperatureFromConsole();
    }

    /// <summary>
    /// Reads <c>fromTime</c>, 
    /// <c>toTime</c> 
    /// and <c>temperature</c> values for existing week program from the Console.
    /// </summary>
    /// <param name="createProgram">The week program to assign the read values to.</param>
    public static void ReadEditProgramValuesFromConsole(CreateProgram createProgram)
    {
        createProgram.FromTime = ReadFromTimeFromConsole();
        createProgram.ToTime = ReadToTimeFromConsole();
        createProgram.ProgramTemp = ReadTemperatureFromConsole();
    }

    /// <summary>
    /// Reads <c>programId</c> value from the Console.
    /// </summary>
    /// <param name="textToShow"><c>edit</c> or <c>delete</c> text to show.</param>
    /// <returns>The read <c>programId</c>.</returns>
    public static string ReadProgramIdFromConsole(string textToShow)
    {
        string selectedId = "";
        do
        {
            Console.Write($"Enter \"Id\" of the week program you wish to {textToShow}: ");
            var inputValue = Console.ReadLine();

            if (inputValue != null)
            {
                selectedId = inputValue.Trim();
            }
        } while (selectedId.Length < 1);

        return selectedId;
    }

    /// <summary>
    /// Reads a <c>dayOfWeek</c> value from the Console.
    /// </summary>
    /// <returns>The read <c>dayOfWeek</c>.</returns>
    public static int ReadDayOfWeekFromConsole()
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
    public static string ReadFromTimeFromConsole()
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
    public static string ReadToTimeFromConsole()
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
    public static short ReadTemperatureFromConsole()
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
    /// Reads EcoTemp <c>newTime</c> value from the Console.
    /// </summary>
    /// <returns>The read <c>timeInMinutes</c>.</returns>
    public static int ReadEcoTempTimeInMinutesFromConsole()
    {
        int timeInMinutes;
        do
        {
            int hours = 0;
            do
            {
                Console.Write("Enter EcoTemp hours [0, 23]: ");
                var inputValue = Console.ReadLine();

                if ((inputValue != null) && (inputValue != ""))
                {
                    hours = int.Parse(inputValue) * 60;
                }
            } while ((hours < 0) || (hours > 1380));

            int minutes = 0;
            do
            {
                Console.Write("Enter EcoTemp minutes [0, 59]: ");
                var inputValue = Console.ReadLine();

                if ((inputValue != null) && (inputValue != ""))
                {
                    minutes = int.Parse(inputValue);
                }
            } while ((minutes < 0) || (minutes > 59));

            timeInMinutes = hours + minutes;

        } while ((timeInMinutes < 0) || (timeInMinutes > 1439));

        return timeInMinutes;
    }

    /// <summary>
    /// Reads SleepMode <c>newTime</c> value from the Console.
    /// </summary>
    /// <returns>The read <c>timeInMinutes</c>.</returns>
    public static int ReadSleepModeTimeInMinutesFromConsole()
    {
        int timeInMinutes;
        do
        {
            int hours = 0;
            do
            {
                Console.Write("Enter SleepMode hours [0, 23]: ");
                var inputValue = Console.ReadLine();

                if ((inputValue != null) && (inputValue != ""))
                {
                    hours = int.Parse(inputValue) * 60;
                }
            } while ((hours < 0) || (hours > 1380));

            int minutes = 0;
            do
            {
                Console.Write("Enter SleepMode minutes [0, 59]: ");
                var inputValue = Console.ReadLine();

                if ((inputValue != null) && (inputValue != ""))
                {
                    minutes = int.Parse(inputValue);
                }
            } while ((minutes < 0) || (minutes > 59));

            timeInMinutes = hours + minutes;

        } while ((timeInMinutes < 0) || (timeInMinutes > 1439));

        return timeInMinutes;
    }

    /// <summary>
    /// Reads DelayedStart <c>newTime</c> value from the Console.
    /// </summary>
    /// <returns>The read <c>timeInMinutes</c>.</returns>
    public static int ReadDelayedStartTimeInMinutesFromConsole()
    {
        int hoursInMinutes = 0;
        do
        {
            Console.Write("Enter DelayedStart hours [0, 96] (if \"0\" is entered, uses default settings): ");
            var inputValue = Console.ReadLine();

            if ((inputValue != null) && (inputValue != ""))
            {
                hoursInMinutes = int.Parse(inputValue) * 60;
            }
        } while ((hoursInMinutes < 0) || (hoursInMinutes > 5760));

        return hoursInMinutes;
    }

    /// <summary>
    /// Reads Device <c>deviceName</c> value from the Console.
    /// </summary>
    /// <returns>The read <c>deviceName</c>.</returns>
    public static string ReadDeviceNameFromConsole()
    {
        string deviceName = "";
        do
        {
            Console.Write("Enter device name: ");
            var inputValue = Console.ReadLine();

            if (inputValue != null)
            {
                deviceName = inputValue.Trim();
            }
        } while (deviceName.Length < 1);

        return deviceName;
    }

    /// <summary>
    /// Reads Device <c>newWifiName</c> value from the Console.
    /// </summary>
    /// <returns>The read <c>newWifiName</c>.</returns>
    public static string ReadDeviceWifiSSIDFromConsole()
    {
        string selectedWifiSSID = "";
        do
        {
            Console.Write("Entet Wifi Network Name: ");
            var inputValue = Console.ReadLine();

            if (inputValue != null)
            {
                selectedWifiSSID = inputValue.Trim();
            }
        } while (selectedWifiSSID.Length < 1);

        return selectedWifiSSID;
    }

    /// <summary>
    /// Reads Device <c>newWifiPassword</c> value from the Console.
    /// </summary>
    /// <returns>The read <c>newWifiPassword</c>.</returns>
    public static string ReadDeviceWifiPassFromConsole()
    {
        string selectedWifiPass = "";
        do
        {
            Console.Write("Enter Wifi Network Password: ");
            var inputValue = Console.ReadLine();

            if (inputValue != null)
            {
                selectedWifiPass = inputValue.Trim();
            }
        } while (selectedWifiPass.Length < 1);

        return selectedWifiPass;
    }

    /// <summary>
    /// Reads TCorrection <c>newTemperature</c> value from the Console.
    /// </summary>
    /// <returns>The read <c>temperature</c>.</returns>
    public static short ReadTCorrectionTemperatureFromConsole()
    {
        short temperature = 0;
        do
        {
            Console.Write("Enter TCorrection temperature [-4, 4]: ");
            var inputValue = Console.ReadLine();

            if (inputValue != null)
            {
                temperature = short.Parse(inputValue);
            }
        } while ((temperature < -4) || (temperature > 4));

        return temperature;
    }

    /// <summary>
    /// Reads Mode <c>name</c> value from the Console.
    /// </summary>
    /// <returns>The read <c>modeName</c>.</returns>
    public static string ReadModeNameFromConsole()
    {
        string modeName = "";
        string[] modes = {"off", "heating", "comfort", "eco", "sleep", "delay start", "program"};
        do
        {
            Console.Write("Enter mode name [off, heating, comfort, eco, sleep, delay start, program]: ");
            var inputValue = Console.ReadLine();

            if ((inputValue != null) && modes.Contains(inputValue))
            {
                modeName = inputValue.Trim();
            }
        } while (modeName.Length < 1);

        return modeName;
    }

    /// <summary>
    /// Reads the TimeZone IANA ID number from the Console.
    /// </summary>
    /// <param name="timeZonesFileContent">The file of TimeZones to search.</param>
    /// <returns>The read <c>ianaId</c>.</returns>
    public static string ReadIanaTimeZoneIdFromConsole(Dictionary<string, TimeZonesFileContent> timeZonesFileContent)
    {
        string ianaId = "";
        do
        {
            Console.Write("Enter IANA ID number for new TimeZone (or leave empty for default TimeZone): ");
            var inputValue = Console.ReadLine();

            if (inputValue == "")
            {
                break;
            }

            if ((inputValue != null) && timeZonesFileContent.ContainsKey(inputValue))
            {
                ianaId = timeZonesFileContent[inputValue.Trim()].IanaId;
            }
        } while (ianaId.Length < 1);

        return ianaId;
    }
}