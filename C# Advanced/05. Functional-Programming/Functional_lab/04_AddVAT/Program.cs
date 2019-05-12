using System;
using System.Linq;

namespace _04_AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                //.Select(n=>n*1.2)
                .ToArray();

            Action<double> print = p => Console.WriteLine($"{p*1.2:f2}");

            foreach (var price in prices)
            {
                print(price);
            }
        }
    }
}
