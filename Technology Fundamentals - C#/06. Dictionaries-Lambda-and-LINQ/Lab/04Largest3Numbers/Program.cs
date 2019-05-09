using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split()
                                               .Select(int.Parse)
                                               .OrderBy(n => -n)
                                               .ToList();
            List<int> result = nums.Take(3).ToList();
            Console.WriteLine(string.Join(' ',result));
        }
    }
}
