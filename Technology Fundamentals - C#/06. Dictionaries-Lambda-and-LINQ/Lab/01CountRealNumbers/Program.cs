using System;
using System.Collections.Generic;
using System.Linq;

namespace _01CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var dict = new SortedDictionary<double, int>();

            foreach(var n in nums)
            {
                if(dict.ContainsKey(n))
                {
                    dict[n]++;
                }

                else
                {
                    dict[n] = 1;
                }
            }

            foreach(var n in dict)
            {
                Console.WriteLine($"{n.Key} -> {n.Value}");
            }
        }
    }
}
