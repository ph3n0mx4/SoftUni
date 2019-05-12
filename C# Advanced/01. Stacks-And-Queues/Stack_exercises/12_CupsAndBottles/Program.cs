using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var bottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var stackBottle = new Stack<int>(bottles);
            var queueCups = new Queue<int>(cups);

            int wastedWater = 0;

            while (true)
            {
                if(stackBottle.Count<1)
                {
                    Console.WriteLine($"Cups: {string.Join(" ",queueCups)}");
                    break;
                }

                else if(queueCups.Count<1)
                {
                    Console.WriteLine($"Bottles: {string.Join(" ",stackBottle)}");
                    break;
                }


                if(stackBottle.Peek()>=queueCups.Peek())
                {
                    int currentBottle = stackBottle.Pop();
                    int currentCup = queueCups.Dequeue();
                    wastedWater += (currentBottle - currentCup);
                    //continue;
                }

                else if (stackBottle.Peek() < queueCups.Peek())
                {
                    int currentCup = queueCups.Dequeue();
                    while(currentCup>0)
                    {
                        int currentBottle = stackBottle.Pop();
                        currentCup -= currentBottle;
                    }

                    if(currentCup<0)
                    {
                        wastedWater += Math.Abs(currentCup);
                    }
                }
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
