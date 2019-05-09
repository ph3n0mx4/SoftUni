using System;
using System.Text.RegularExpressions;

namespace _02Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @">>(?<name>.+)<<(?<price>\d+[\.\d]*?)!(?<count>\d+)";
            string input = Console.ReadLine();
            double money = 0;
            Console.WriteLine("Bought furniture:");

            while (input!= "Purchase")
            {
                Match match = Regex.Match(input, regex);

                if(!match.Success)
                {
                    input = Console.ReadLine();
                    continue;
                }
                string name = match.Groups["name"].Value;
                double price = double.Parse(match.Groups["price"].Value);
                double count = double.Parse(match.Groups["count"].Value);
                Console.WriteLine(name);
                money += price * count;
                
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total money spend: {money:f2}");
        }
    }
}
