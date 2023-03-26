using CommandLine;

namespace KakaoChatParser
{
    /// <summary>
    /// The command line options class.
    /// </summary>
    internal class Options
    {
        /// <summary>
        /// Gets or sets the input file path.
        /// </summary>
        [Option("filepath", Required = true, HelpText = "Kakaotalk's text input file path.")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string FilePath { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// Gets or sets the output file path (in a folder format, without the filename).
        /// </summary>
        [Option("outputpath", Required = true, HelpText = "OutputPath for the csv file.")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string OutputPath { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// Gets or sets the optional start date to start the search from.
        /// </summary>
        [Option("startdate", Required = false, HelpText = "Optional start date (inclusive). If not found, finds the closest date that is greater than the given date. If not provided, the tool will start grabbing chats from the beginning of the input file.")]
        public string? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the optional end date to stop the search from.
        /// </summary>
        [Option("enddate", Required = false, HelpText = "Optional end date (exclusive). If not found, finds the closest date that is greater than the given date. If not provided, the tool will start grabbing chats until the end of the input file.")]
        public string? EndDate { get; set; }
    }
}
