namespace KakaoChatParser
{
    /// <summary>
    /// Class for date formats.
    /// </summary>
    internal static class DateFormats
    {
        /// <summary>
        /// The dictionary that maps each supported date format to its expected raw string format.
        /// </summary>
        internal static readonly IDictionary<SupportedDateFormat, string> FormatMapping = new Dictionary<SupportedDateFormat, string>
        {
            { SupportedDateFormat.NumberFormat, "yyyyMMdd" },
            { SupportedDateFormat.EnglishFormat, "--------------- dddd, MMMM dd, yyyy ---------------" },
        };
    }
}
