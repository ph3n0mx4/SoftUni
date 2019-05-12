using System;
using System.Linq;

namespace _03_CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func<int[], int> minFunc = MinValue;

            Func<int[], int> minFunc2 = x =>
            {
                return x.Min();

            };

            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //Console.WriteLine(minFunc(nums));
            Console.WriteLine(minFunc2(nums));
        }

        //private static int MinValue(int[] arg)
        //{
        //    return arg.Min();
        //}
    }
}
