using CommandLine;

namespace KakaoChatParser
{
    internal class Options
    {
        [Option("filepath", Required = true, HelpText = "Kakaotalk text file path.")]
        public string FilePath { get; set; }

        [Option("outputpath", Required = true, HelpText = "OutputPath for the csv file.")]
        public string OutputPath { get; set; }

        [Option("startdate", Required = false, HelpText = "Optional start date (inclusive). If not found, finds the closest date that is greater than the given date.")]
        public string? StartDate { get; set; }

        [Option("enddate", Required = false, HelpText = "Optional end date (exclusive). If not found, finds the closest date that is greater than the given date.")]
        public string? EndDate { get; set; }
    }
}
