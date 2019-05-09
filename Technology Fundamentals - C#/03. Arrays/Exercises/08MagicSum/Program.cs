using System;
using System.Linq;

namespace _08MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToArray();

            int numberSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length-1; i++)
            {
                for (int j = i+1; j < numbers.Length; j++)
                {
                    int sum = numbers[i] + numbers[j];

                    if (sum==numberSum)
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[j]}");
                    }
                }
            }
        }
    }
}
