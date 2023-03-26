namespace KakaoChatParser
{
    /// <summary>
    /// The supported date format.
    /// </summary>
    internal enum SupportedDateFormat
    {
        /// <summary>
        /// yyyyMMdd number format. (e.g. 20230325)
        /// </summary>
        NumberFormat,

        /// <summary>
        /// dddd, MMMM dd, yyyy english format. (e.g. --------------- Wednesday, January 25, 2023 ---------------)
        /// </summary>
        EnglishFormat,
    }
}
