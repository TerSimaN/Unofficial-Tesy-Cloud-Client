using System.Globalization;
using Tesy.Enums;

namespace Tesy.Classes
{
    public class WorldClock
    {
        private readonly CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
        private readonly DateTimeFormatInfo dateTimeFormatInfo;
        private DateTime dateTime = new();

        public WorldClock()
        {
            dateTimeFormatInfo = cultureInfo.DateTimeFormat;
            dateTimeFormatInfo.LongDatePattern = "yyyy-MM-dd";
            dateTimeFormatInfo.LongTimePattern = "HH:mm";
        }

        public string GetNewTimeZoneTime(string timeZoneIanaId)
        {
            DateTime local = DateTime.Now;
            TimeZoneInfo.TryConvertIanaIdToWindowsId(timeZoneIanaId, out string? timeZoneWindowsId);
            if (timeZoneWindowsId != null)
            {
                dateTime = TimeZoneInfo.ConvertTime(local, TimeZoneInfo.FindSystemTimeZoneById(timeZoneWindowsId));
                TimeOnly time = TimeOnly.FromDateTime(dateTime);

                return time.ToString("T", cultureInfo);
            }

            return "";
        }

        public string GetNewTimeZoneDate(string timeZoneIanaId)
        {
            DateTime local = DateTime.Now;
            TimeZoneInfo.TryConvertIanaIdToWindowsId(timeZoneIanaId, out string? timeZoneWindowsId);
            if (timeZoneWindowsId != null)
            {
                dateTime = TimeZoneInfo.ConvertTime(local, TimeZoneInfo.FindSystemTimeZoneById(timeZoneWindowsId));
                DateOnly date = DateOnly.FromDateTime(dateTime);

                return date.ToString("D", cultureInfo);
            }

            return "";
        }

        public short GetNewWeekday(string timeZoneIanaId)
        {
            short day = 0;
            DateTime local = DateTime.Now;
            TimeZoneInfo.TryConvertIanaIdToWindowsId(timeZoneIanaId, out string? timeZoneWindowsId);
            if (timeZoneWindowsId != null)
            {
                dateTime = TimeZoneInfo.ConvertTime(local, TimeZoneInfo.FindSystemTimeZoneById(timeZoneWindowsId));

                switch (dateTime.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        day = (short)WeekDays.Monday;
                        break;
                    case DayOfWeek.Tuesday:
                        day = (short)WeekDays.Tuesday;
                        break;
                    case DayOfWeek.Wednesday:
                        day = (short)WeekDays.Wednesday;
                        break;
                    case DayOfWeek.Thursday:
                        day = (short)WeekDays.Thursday;
                        break;
                    case DayOfWeek.Friday:
                        day = (short)WeekDays.Friday;
                        break;
                    case DayOfWeek.Saturday:
                        day = (short)WeekDays.Saturday;
                        break;
                    case DayOfWeek.Sunday:
                        day = (short)WeekDays.Sunday;
                        break;
                    default:
                        break;
                }
            }

            return day;
        }
    }
}