using System.Globalization;
using System.Text.RegularExpressions;

namespace KakaoChatParser
{
    /// <summary>
    /// The utilities class.
    /// </summary>
    internal static class Utilities
    {
        /// <summary>
        /// Gets the first date from the command line date format. If null, returns the <see cref="DateTime.MinValue"/>.
        /// </summary>
        /// <param name="firstDate">The optional first date to start searching.</param>
        /// <returns>The <see cref="DateTime"/>.</returns>
        internal static DateTime GetFirstDate(string? firstDate)
        {
            if (firstDate is null)
            {
                return DateTime.MinValue;
            }

            return ParseDate(firstDate, SupportedDateFormat.NumberFormat);
        }

        /// <summary>
        /// Gets the end date from the command line date format. If null, returns the <see cref="DateTime.MaxValue"/>.
        /// </summary>
        /// <param name="endDate">The optional end date to stop searching.</param>
        /// <returns>The <see cref="DateTime"/>.</returns>
        internal static DateTime GetEndDate(string? endDate)
        {
            if (endDate is null)
            {
                return DateTime.MaxValue;
            }

            return ParseDate(endDate, SupportedDateFormat.NumberFormat);
        }

        /// <summary>
        /// Parses the date given the <see cref="SupportedDateFormat"/>.
        /// </summary>
        /// <param name="date">The raw date string.</param>
        /// <param name="format">The <see cref="SupportedDateFormat"/>.</param>
        /// <returns>The parsed <see cref="DateTime"/>.</returns>
        internal static DateTime ParseDate(string date, SupportedDateFormat format)
        {
            var input = DateFormats.FormatMapping[format];
            return DateTime.ParseExact(date, input, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Determines whether the given string is in the expected date format.
        /// </summary>
        /// <param name="line">The raw string.</param>
        /// <returns>Whether the given string is in the expected date format.</returns>
        internal static bool IsDate(string line) => Regex.IsMatch(line, Regexes.DateRegex);

        /// <summary>
        /// Determines whether the given string is in the expected chat format.
        /// </summary>
        /// <param name="line">The raw string.</param>
        /// <returns>Whether the given string is in the expected chat format.</returns>
        internal static bool IsChat(string line) => Regex.IsMatch(line, Regexes.ChatRegex);
    }
}
