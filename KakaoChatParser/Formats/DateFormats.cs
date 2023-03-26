namespace KakaoChatParser
{
    internal static class DateFormats
    {
        internal static readonly IDictionary<SupportedDateFormat, string> FormatMapping = new Dictionary<SupportedDateFormat, string>
        {
            { SupportedDateFormat.NumberFormat, "yyyyMMdd" },
            { SupportedDateFormat.EnglishFormat, "--------------- dddd, MMMM dd, yyyy ---------------" },
        };
    }
}
