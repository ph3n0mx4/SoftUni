using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace _01_BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ").ToArray();
            int n = int.Parse(input[0]);
            int s = int.Parse(input[1]);
            int x = int.Parse(input[2]);

            var nums = Console.ReadLine().Split(" ");
            Stack<int> stack = new Stack<int>();

            foreach (var num in nums)
            {
                int currentNum = int.Parse(num);
                stack.Push(currentNum);
            }

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            var arr =stack.ToList();

            if(stack.Contains(x))
            {
                Console.WriteLine("true");
            }

            else
            {
                arr.Sort();
                Console.WriteLine(arr[0]);
            }
        }
    }
}
