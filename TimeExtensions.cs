
namespace System.Extensions
{
    public static class TimeExtensions
    {
        #region DateTime

        /// <summary>
        /// Gets the remaining minutes until the end of the current day.
        /// </summary>
        /// <param name="date">The DateTime instance.</param>
        /// <returns>The remaining minutes until midnight.</returns>
        public static double GetRemainingMinutes(this DateTime date)
        {
            TimeSpan day = TimeSpan.FromDays(1);
            return day.GetDifferenceInMinutes(date.TimeOfDay);
        }

        /// <summary>
        /// Gets the remaining seconds until the end of the current day.
        /// </summary>
        /// <param name="date">The DateTime instance.</param>
        /// <returns>The remaining seconds until midnight.</returns>
        public static double GetRemainingSeconds(this DateTime date)
        {
            TimeSpan day = TimeSpan.FromDays(1);
            return day.GetDifferenceInSeconds(date.TimeOfDay);
        }

        /// <summary>
        /// Calculates the difference in minutes between two DateTime values.
        /// </summary>
        /// <param name="date">The base DateTime instance.</param>
        /// <param name="value">The DateTime to compare.</param>
        /// <returns>The difference in minutes.</returns>
        public static double GetDifferenceInMinutes(this DateTime date, DateTime value)
        {
            return date.Subtract(value).TotalMinutes;
        }

        /// <summary>
        /// Calculates the difference in seconds between two DateTime values.
        /// </summary>
        /// <param name="date">The base DateTime instance.</param>
        /// <param name="value">The DateTime to compare.</param>
        /// <returns>The difference in seconds.</returns>
        public static double GetDifferenceInSeconds(this DateTime date, DateTime value)
        {
            return date.Subtract(value).TotalSeconds;
        }

        /// <summary>
        /// Gets the day of the week as a string representation.
        /// </summary>
        /// <param name="date">The DateTime instance.</param>
        /// <returns>The string representation of the day of the week.</returns>
        public static string GetWeekString(this DateTime date)
        {
            return date.DayOfWeek.ToString();
        }

        /// <summary>
        /// Converts the DateTime to a Unix timestamp in seconds.
        /// </summary>
        /// <param name="date">The DateTime instance.</param>
        /// <returns>The Unix timestamp.</returns>
        public static long ToUnixTime(this DateTime date)
        {
            DateTimeOffset offset = new DateTimeOffset(date);
            return offset.ToUnixTimeSeconds();
        }

        #endregion

        #region TimeSpan

        /// <summary>
        /// Calculates the difference in minutes between two TimeSpan values.
        /// </summary>
        /// <param name="span">The base TimeSpan instance.</param>
        /// <param name="value">The TimeSpan to compare.</param>
        /// <returns>The difference in minutes.</returns>
        public static double GetDifferenceInMinutes(this TimeSpan span, TimeSpan value)
        {
            return span.Subtract(value).TotalMinutes;
        }

        /// <summary>
        /// Calculates the difference in seconds between two TimeSpan values.
        /// </summary>
        /// <param name="span">The base TimeSpan instance.</param>
        /// <param name="value">The TimeSpan to compare.</param>
        /// <returns>The difference in seconds.</returns>
        public static double GetDifferenceInSeconds(this TimeSpan span, TimeSpan value)
        {
            return span.Subtract(value).TotalSeconds;
        }

        #endregion
    }
}