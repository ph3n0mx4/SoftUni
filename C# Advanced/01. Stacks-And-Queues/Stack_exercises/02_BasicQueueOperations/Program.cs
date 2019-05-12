using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02_BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integer = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int n = integer[0];
            int s = integer[1];
            int x = integer[2];

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(nums[i]);
            }

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if(queue.Count==0)
            {
                Console.WriteLine(0);
                return;
            }


            if(queue.Contains(x))
            {
                Console.WriteLine("true");
            }

            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
