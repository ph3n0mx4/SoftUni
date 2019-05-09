using System;
using System.Text.RegularExpressions;

namespace _03SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            double sum = 0;
            while((input=Console.ReadLine())!= "end of shift")
            {
                string regex = @"\%(?<=\%)(?<customer>[A-Z][a-z]+)(?=\%)\%(([^\%\|\.\$]+)?)\<(?<=\<)(?<product>[\w]+)(?=\>)\>(([^\%\|\.\$]+)?)\|(?<=\|)(?<num>[0-9]{1,2})(?=\|)\|(([^\%\|\.\$]+[^0-9\.]+)?)(?<price>\d+(\.\d+)?)(?=\$)\$";
                Match match = Regex.Match(input, regex);
                if(!match.Success)
                {
                    continue;
                }

                string customer = match.Groups["customer"].Value;
                string product = match.Groups["product"].Value;
                double num = double.Parse(match.Groups["num"].Value);
                double price = double.Parse(match.Groups["price"].Value);
                double totalPrice = num * price;
                sum += totalPrice;
                Console.WriteLine($"{customer}: {product} - {totalPrice:f2}");
            }
            Console.WriteLine($"Total income: { sum:f2}");
        }
    }
}
