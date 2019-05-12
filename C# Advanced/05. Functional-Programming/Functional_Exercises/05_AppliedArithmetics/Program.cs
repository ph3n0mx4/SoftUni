using System;
using System.Linq;

namespace _05_AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> print = x => Console.WriteLine(string.Join(" ",x));

            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string cmd = Console.ReadLine();
            while (cmd.ToLower() !="end")
            {
                //"add" -> add 1 to each number; "multiply" -> multiply each number by 2; "subtract" -> subtract 1 from each number; “print” -> print the collection. 
                if (cmd.ToLower()=="add")
                {
                    numbers = numbers.Select(x=>x+1).ToArray();
                }

                else if(cmd.ToLower() == "multiply")
                {
                    numbers = numbers.Select(x => x *2).ToArray();
                }

                else if (cmd.ToLower() == "subtract")
                {
                    numbers = numbers.Select(x => x-1).ToArray();
                }

                else if (cmd.ToLower() == "print")
                {
                    print(numbers);
                }
                cmd = Console.ReadLine();
            }
        }
    }
}
