﻿using System.Text.RegularExpressions;

namespace KakaoChatParser
{
    internal class Runner
    {
        private readonly string OutputFileName = "output.csv";
        private readonly Options options;

        public Runner(Options options)
        {
            this.options = options;
        }

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

                            if (IsFirstDate(date, firstDate))
                            {
                                sawFirstDate = true;
                            }
                        }

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

                            if (IsEndDate(date, endDate))
                            {
                                sawEndDate = true;
                                break;
                            }
                        }
                    }
                }
            }

            var sortedDict = dictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            var outputPath = Path.Combine(options.OutputPath, OutputFileName);
            sortedDict.WriteToCSV(outputPath);

            Console.WriteLine($"Ran the program and saved the final output to: {outputPath}");
        }
        
        private bool IsFirstDate(DateTime date, DateTime firstDate) => date >= firstDate;
        
        private bool IsEndDate(DateTime date, DateTime endDate) => date >= endDate;
    }
}
