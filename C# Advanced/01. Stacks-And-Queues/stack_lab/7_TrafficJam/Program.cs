using System;
using System.Collections;
using System.Collections.Generic;

namespace _8_TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int counter = 0;
            string cmd = Console.ReadLine();
            Queue<string> queue = new Queue<string>();

            while(cmd!="end")
            {
                if(cmd=="green")
                {
                    for (int i = 0; i < num && queue.Count>0; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        counter++;
                    }
                }

                else
                {
                    queue.Enqueue(cmd);
                }
                
                cmd = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
