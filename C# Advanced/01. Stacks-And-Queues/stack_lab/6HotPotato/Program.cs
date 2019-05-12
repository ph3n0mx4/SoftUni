using System;
using System.Collections.Generic;
using System.Linq;

namespace _6HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split(" ");
            int num = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(children);

            while(queue.Count!=1)
            {
                for (int i = 1; i < num; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
