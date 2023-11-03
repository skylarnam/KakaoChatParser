namespace KakaoChatParser.Formats
{
    /// <summary>
    /// The output format of the csv.
    /// </summary>
    /// <param name="Nickname">The nickname.</param>
    /// <param name="ChatCount">The chat count.</param>
    internal record Output(string Nickname, int ChatCount);
}
