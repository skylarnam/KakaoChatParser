using System.Globalization;
using System.Text.RegularExpressions;

namespace KakaoChatParser
{
    internal static class Utilities
    {
        internal static DateTime GetFirstDate(string? firstDate)
        {
            if (firstDate is null)
            {
                return DateTime.MinValue;
            }

            return ParseDate(firstDate, SupportedDateFormat.NumberFormat);
        }

        internal static DateTime GetEndDate(string? endDate)
        {
            if (endDate is null)
            {
                return DateTime.MaxValue;
            }

            return ParseDate(endDate, SupportedDateFormat.NumberFormat);
        }

        internal static DateTime ParseDate(string date, SupportedDateFormat format)
        {
            var input = DateFormats.FormatMapping[format];
            return DateTime.ParseExact(date, input, CultureInfo.InvariantCulture);
        }

        internal static bool IsDate(string line) => Regex.IsMatch(line, Regexes.DateRegex);

        internal static bool IsChat(string line) => Regex.IsMatch(line, Regexes.ChatRegex);
    }
}
