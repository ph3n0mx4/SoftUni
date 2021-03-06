﻿using System;
using System.Linq;

namespace _01_SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortEvenNums = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x=>x)
                .ToArray();
            Console.WriteLine(string.Join(", ",sortEvenNums));
                
        }
    }
}
