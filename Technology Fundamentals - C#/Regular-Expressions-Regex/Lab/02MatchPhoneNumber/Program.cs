using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(\+359-2-\d{3}-[0-9]{4}(?!\d+))|(\+359 2 \d{3} \d{4}(?!\d+))";

            string phones = Console.ReadLine();

            MatchCollection phoneMatches = Regex.Matches(phones, regex);

            var matchedPhones = phoneMatches.Cast<Match>().Select(x => x.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ",matchedPhones));
            
        }
    }
}
