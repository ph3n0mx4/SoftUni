using System;
using System.Text.RegularExpressions;

namespace _01ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(?<![\w\-\.])[a-z][\w\-\.]+@[a-z\-]+.[a-z]+(\.[a-z]+)+?";
            string data = Console.ReadLine();

            MatchCollection mails = Regex.Matches(data, regex);

            foreach (Match mail in mails)
            {
                Console.WriteLine(mail.Value);
            }
        }
    }
}
