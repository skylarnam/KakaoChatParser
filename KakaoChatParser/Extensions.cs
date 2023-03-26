using CsvHelper;
using System.Globalization;
using System.Text;

namespace KakaoChatParser
{
    internal static class Extensions
    {
        internal static void InitializeOrIncrement<T>(this IDictionary<T, int> dictionary, T key)
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

        internal static void WriteToCSV<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, string outputPath)
        {
            using (var writer = new StreamWriter(outputPath, false, Encoding.UTF8))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(dictionary);
            }
        }
    }
}
