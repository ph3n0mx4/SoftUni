using System;
using System.Text.RegularExpressions;

namespace _03MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {                                                      //tuk e 1 \/ c# ne broi name capture group
            string regex = @"(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})";
            string data = Console.ReadLine();

            MatchCollection dates = Regex.Matches(data, regex);

            foreach (Match item in dates)
            {
                var day = item.Groups["day"].Value;
                var month = item.Groups["month"].Value;
                var year = item.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
