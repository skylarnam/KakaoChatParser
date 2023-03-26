using CommandLine;

namespace KakaoChatParser;

/// <summary>
/// The KakaoChatParser tool.
/// </summary>
public class Program
{
    /// <summary>
    /// The entry method of the tool.
    /// </summary>
    /// <param name="args">The raw command line arguments.</param>
    /// <exception cref="ArgumentException">When the parser fails to parse arguments.</exception>
    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(Run)
            .WithNotParsed(e => throw new ArgumentException());
    }

    private static void Run(Options options)
    {
        var runner = new Runner(options);
        runner.Run();
    }
}
