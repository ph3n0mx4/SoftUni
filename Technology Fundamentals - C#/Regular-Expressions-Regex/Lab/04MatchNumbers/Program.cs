using System;
using System.Text.RegularExpressions;

namespace _04MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";
            string data = Console.ReadLine();

            MatchCollection nums = Regex.Matches(data, regex);

            foreach (Match item in nums)
            {
                Console.Write(item.Value+" ");
            }
            Console.WriteLine();
        }
    }
}
