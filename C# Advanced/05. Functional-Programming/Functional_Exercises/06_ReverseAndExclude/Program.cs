using System;
using System.Linq;

namespace _06_ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToArray();

            int divisible = int.Parse(Console.ReadLine());

            Predicate<int> filterPredicate = x => x % divisible != 0;

            Console.WriteLine(string.Join(" ",numbers.Where(x=>filterPredicate(x))));
        }
    }
}
