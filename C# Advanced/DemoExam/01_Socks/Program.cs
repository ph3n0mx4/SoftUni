using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            var leftSequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rightSequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var left = new Stack<int>(leftSequence);
            var right = new Queue<int>(rightSequence);

            var result = new List<int>();
            while (left.Count>0 && right.Count>0)
            {
                int currentLeft = left.Peek();
                int currentRight = right.Peek();

                if(currentLeft>currentRight)
                {
                    result.Add(currentLeft + currentRight);
                    left.Pop();
                    right.Dequeue();
                }

                else if(currentLeft==currentRight)
                {
                    right.Dequeue();
                    left.Push(left.Pop() + 1);
                }

                else
                {
                    left.Pop();
                }
            }

            Console.WriteLine(result.Max());
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
