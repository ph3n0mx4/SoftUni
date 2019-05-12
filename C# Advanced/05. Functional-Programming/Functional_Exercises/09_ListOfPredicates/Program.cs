using System;
using System.Linq;

namespace _09_ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            //numbers.AddRange(Enumerable.Range(start, count)); - add int in range from x to y (count = y-x+1)
            int endOfTheRange = int.Parse(Console.ReadLine());

            if(endOfTheRange<1)
            {
                return;
            }
            var dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int, bool> filter = (allDividers, number) =>
            {
                bool divisible = true;

                for (int i = 0; i < dividers.Length; i++)
                {
                    int currnetDivider = dividers[i];

                    if(number%currnetDivider!=0)
                    {
                        divisible = false;
                        break;
                    }
                }
                return divisible;
            };

            var numbers = Enumerable.Range(1, endOfTheRange).Where(n => filter(dividers, n)).ToArray();

            Console.WriteLine(string.Join(" ",numbers));

        }
    }
}
