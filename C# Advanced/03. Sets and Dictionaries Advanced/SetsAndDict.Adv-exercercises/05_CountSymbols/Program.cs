using System;
using System.Collections.Generic;

namespace _05_CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var chars = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if(!chars.ContainsKey(currentChar))
                {
                    chars[currentChar] = 0;
                }

                chars[currentChar]++;
            }

            foreach (var @char in chars)
            {
                Console.WriteLine($"{@char.Key}: {@char.Value} time/s");
                
            }
        }
    }
}
