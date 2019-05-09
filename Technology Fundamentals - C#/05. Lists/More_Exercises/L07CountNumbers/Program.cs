using System;
using System.Collections.Generic;
using System.Linq;

namespace L07CountNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                                    .Split().Select(int.Parse).ToList();
            nums.Sort();
            int count = 1;
            for (int pos = 0; pos < nums.Count; pos++)
            {
                int num = nums[pos];
                if((pos < (nums.Count - 1) && nums[pos] != nums[pos + 1]) || pos == (nums.Count - 1))
                {
                    Console.WriteLine($"{num} -> {count}");
                    count = 0;
                }
                count++;
            }
        }
    }
}
