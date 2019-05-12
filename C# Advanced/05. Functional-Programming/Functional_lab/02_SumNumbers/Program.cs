using System;
using System.Linq;

namespace _02_SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = n=>int.Parse(n);

            var nums = Console.ReadLine()
                .Split(", ")
                .Select(parser)
                .ToArray();
            Console.WriteLine(nums.Count());
            Console.WriteLine(nums.Sum());
        }
    }
}
