namespace KakaoChatParser
{
    /// <summary>
    /// Defines the Regex formats used for parsing.
    /// </summary>
    internal static class Regexes
    {
        /// <summary>
        /// The date format used by KakaoTalk. (e.g. "--------------- Friday, January 20, 2023 ---------------")
        /// </summary>
        public static string DateRegex = @"^---------------\s\w+,\s\w+\s\d+,\s\d{4}\s---------------$";

        /// <summary>
        /// The chat format used by KakaoTalk. (e.g. "[nickname] [5:27 PM] Hello!")
        /// </summary>
        public static string ChatRegex = @"^\[([^\]]+)\]\s\[\d{1,2}:\d{2}\s(?:AM|PM)\]\s.*$";
    }
}
