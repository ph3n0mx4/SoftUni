using System;
using System.Collections.Generic;
using System.Linq;

namespace _1_CountSameValuesInArray__
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var numbers = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                double num = input[i];

                if(!numbers.ContainsKey(num))
                {
                    numbers[num] = 0;
                }

                numbers[num]++;
            }

            foreach (var kvp in numbers)
            {
                //2 - 3 times
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
