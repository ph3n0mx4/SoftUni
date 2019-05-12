using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03_MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                switch (input[0])
                {
                    case 1:
                        if (input[1] > 0 && input[1]<110)
                        {
                            stack.Push(input[1]);
                        }
                        
                        break;
                    case 2:
                        if(stack.Count>0)
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;

                    case 4:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
