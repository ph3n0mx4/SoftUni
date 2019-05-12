using System;
using System.Linq;

namespace _08_CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Action<int[], int[]> print =(x,y)=> Console.WriteLine($"{string.Join(" ", x)} {string.Join(" ", y)}");
            Func<int, int, int> sortFunc = (x, y) => x.CompareTo(y);

            var oddNums = nums.Where(x => x % 2 != 0).ToArray();
            var evenNums = nums.Where(x => x % 2 == 0).ToArray();

            Array.Sort(oddNums, new Comparison<int>(sortFunc));
            Array.Sort(evenNums, new Comparison<int>(sortFunc));

            print(evenNums, oddNums);
        }
    }
}
