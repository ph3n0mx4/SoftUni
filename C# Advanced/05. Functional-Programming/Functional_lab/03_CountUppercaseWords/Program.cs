using System;
using System.Linq;

namespace _03_CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> upperCase = n => char.IsUpper(n[0]);

            var input = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Where(upperCase)
                .ToArray();

            Action<string> print = x => Console.WriteLine(x);

            foreach (var w in input)
            {
                print(w);
            }
        }
    }
}
