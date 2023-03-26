using CommandLine;

namespace KakaoChatParser;

public class Program
{
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
