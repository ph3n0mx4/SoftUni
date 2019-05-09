using System;
using System.Collections.Generic;
using System.Linq;

namespace _05SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> someNums = Console.ReadLine()
                                         .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                         .Select(double.Parse)
                                         .ToList();
            someNums.Sort();
            Console.WriteLine(string.Join(" <= ",someNums));
        }
    }
}
