namespace KakaoChatParser
{
    internal static class Regexes
    {
        public static string DateRegex = @"^---------------\s\w+,\s\w+\s\d+,\s\d{4}\s---------------$";
        public static string ChatRegex = @"^\[([^\]]+)\]\s\[\d{1,2}:\d{2}\s(?:AM|PM)\]\s.*$";
    }
}
