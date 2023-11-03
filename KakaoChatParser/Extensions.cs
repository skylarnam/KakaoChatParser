using CsvHelper;
using KakaoChatParser.Formats;
using System.Globalization;
using System.Text;

namespace KakaoChatParser
{
    /// <summary>
    /// Extensions class for the tool.
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Initializes or increments the value within the dictionary given a key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="dictionary">The <see cref="IDictionary{TKey, int}"/>.</param>
        /// <param name="key">The key.</param>
        internal static void InitializeOrIncrement<TKey>(this IDictionary<TKey, int> dictionary, TKey key)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] += 1;
            }
            else
            {
                dictionary[key] = 1;
            }
        }

        /// <summary>
        /// Writes the current dictionary to CSV with the UTF-8 mapping.
        /// </summary>
        /// <typeparam name="TKey">The key.</typeparam>
        /// <typeparam name="TValue">The value.</typeparam>
        /// <param name="output">The <see cref="IEnumerable<Output>"/>.</param>
        /// <param name="outputPath">The output path.</param>
        internal static void WriteToCSV(this IEnumerable<Output> output, string outputPath)
        {
            using (var writer = new StreamWriter(outputPath, false, Encoding.UTF8))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(output);
            }
        }
    }
}
