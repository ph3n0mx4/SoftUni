using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _11_KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfBarel = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligence = int.Parse(Console.ReadLine());

            var stackBullets = new Stack<int>();
            var queueLocks = new Queue<int>();

            foreach (var bullet in bullets)
            {
                stackBullets.Push(bullet);
            }

            foreach (var @lock in locks)
            {
                queueLocks.Enqueue(@lock) ;
            }

            int counter = 0;

            while(true)
            {
                if(queueLocks.Peek()<stackBullets.Peek())
                {
                    stackBullets.Pop();
                    Console.WriteLine("Ping!");
                    intelligence -= priceOfBullet;
                    
                }

                else
                {
                    queueLocks.Dequeue();
                    stackBullets.Pop();
                    intelligence -= priceOfBullet;
                    Console.WriteLine("Bang!");
                    
                }

                counter++;

                if (counter % sizeOfBarel == 0 && stackBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }

                if (queueLocks.Count < 1)
                {
                    Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${intelligence}");
                    break;
                }

                else if (stackBullets.Count < 1)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
                    break;
                }

                
            }
        }
    }
}
