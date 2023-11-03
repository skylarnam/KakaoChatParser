using KakaoChatParser.Formats;
using System.Text.RegularExpressions;

namespace KakaoChatParser
{
    /// <summary>
    /// The runner class used for the tool.
    /// </summary>
    internal class Runner
    {
        private readonly string OutputFileName = "output.csv";
        private readonly Options options;

        /// <summary>
        /// Creates the runner class for the tool.
        /// </summary>
        /// <param name="options">The command line <see cref="Options"/>.</param>
        public Runner(Options options)
        {
            this.options = options;
        }

        /// <summary>
        /// Starts the runner.
        /// </summary>
        public void Run()
        {
            var dictionary = new Dictionary<string, int>();

            var firstDate = Utilities.GetFirstDate(options.StartDate);
            var sawFirstDate = options.StartDate is null ? true : false;

            var endDate = Utilities.GetEndDate(options.EndDate);
            var sawEndDate = options.EndDate is null ? true : false;

            using (var file = new StreamReader(this.options.FilePath))
            {
                string? ln;

                while ((ln = file.ReadLine()) is not null)
                {
                    if (!sawFirstDate)
                    {
                        if (Utilities.IsDate(ln))
                        {
                            var date = Utilities.ParseDate(ln, SupportedDateFormat.EnglishFormat);

                            // If the exact first date is missing, get the next closest one.
                            if (IsFirstDate(date, firstDate))
                            {
                                sawFirstDate = true;
                            }
                        }

                        // Continue until the first date is seen.
                        continue;
                    }

                    if (Utilities.IsChat(ln))
                    {
                        var nickname = new Regex(Regexes.ChatRegex).Match(ln).Groups[1].Value;
                        dictionary.InitializeOrIncrement(nickname);
                    }

                    if (!sawEndDate)
                    {
                        if (Utilities.IsDate(ln))
                        {
                            var date = Utilities.ParseDate(ln, SupportedDateFormat.EnglishFormat);

                            // If the exact end date is missing, get the next closest one.
                            if (IsEndDate(date, endDate))
                            {
                                sawEndDate = true;
                                break;
                            }
                        }
                    }
                }
            }

            var outputPath = Path.Combine(options.OutputPath, OutputFileName);

            var outputs = new List<Output>();
            outputs.AddRange(dictionary.Select(x => new Output(x.Key, x.Value)));

            var orderedOutputs = outputs.OrderByDescending(x => x.ChatCount);
            orderedOutputs.WriteToCSV(outputPath);

            Console.WriteLine($"Ran the program and saved the final output to: {outputPath}");
        }
        
        private bool IsFirstDate(DateTime date, DateTime firstDate) => date >= firstDate;
        
        private bool IsEndDate(DateTime date, DateTime endDate) => date >= endDate;
    }
}
