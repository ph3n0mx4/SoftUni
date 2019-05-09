using System;
using System.Collections.Generic;
using System.Linq;
namespace _05BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] numBomb = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < nums.Count; i++)
            {
                if(nums[i]==numBomb[0])
                {
                    int startIndex = i - numBomb[1];
                    int endIndex = i + numBomb[1];
                    
                    if(startIndex<0)
                    {
                        startIndex = 0;
                    }

                    if(endIndex>nums.Count-1)
                    {
                        endIndex = nums.Count - 1;
                    }

                    nums.RemoveRange(startIndex, endIndex - startIndex + 1);
                    i = -1;
                }
            }

            Console.WriteLine(nums.Sum());

        }
    }
}
