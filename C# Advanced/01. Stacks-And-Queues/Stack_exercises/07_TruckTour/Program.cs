using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> difference = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                difference.Enqueue(input[0] - input[1]);
            }
            int index = 0;
            while(true)
            {
                var copyDiff = new Queue<int>(difference);
                int fuel = -1;
                while(copyDiff.Any())
                {
                    if(copyDiff.Peek() >= 0 && fuel==-1)
                    {
                        fuel = copyDiff.Dequeue();
                        difference.Dequeue();
                    }

                    else if(copyDiff.Peek()<0 && fuel==-1)
                    {
                        copyDiff.Dequeue();
                        difference.Dequeue();
                        index++;
                    }

                    else
                    {
                        fuel += copyDiff.Dequeue();

                        if(fuel<0)
                        {
                            break;
                        }
                    }
                }

                if(fuel >=0)
                {
                    Console.WriteLine(index);
                    return;
                }

                index++;
            }
            
        }
    }
}
