using System;
using System.Linq;

namespace _02_KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print =x=> Console.WriteLine($"Sir {x}");

            var words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var word in words)
            {
                print(word);
            }
        }
    }
}
