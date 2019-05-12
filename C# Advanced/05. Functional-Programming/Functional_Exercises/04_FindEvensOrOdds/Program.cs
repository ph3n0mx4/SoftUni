using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int start = input[0];
            int count = input[1]-input[0]+1;

            string condition = Console.ReadLine();
            Func<int,bool> filterPredicate;
            if(condition=="odd")
            {
                filterPredicate = x => Math.Abs(x) % 2 == 1;
            }

            else
            {
                filterPredicate = x => Math.Abs(x) % 2 == 0;
            }

            var numbers = Enumerable.Range(start, count)
                .Where(filterPredicate)
                .ToList();
            Console.WriteLine(string.Join(" ",numbers));    
            //numbers.AddRange(Enumerable.Range(start, count)); - add int in range from x to y (count = y-x+1)
            
        }
    }
}
