using System;
using System.Linq;

namespace _01_ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = p => Console.WriteLine(p);

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
