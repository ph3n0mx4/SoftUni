using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var input2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var bottles = new Stack<int>(input2);
            var cups = new Queue<int>(input);

            int wastedWater = 0;
            while (bottles.Count>0 && cups.Count>0)
            {
                int currentBottles = bottles.Peek();
                int currentCups = cups.Peek();

                if(currentBottles>=currentCups)
                {
                    bottles.Pop();
                    cups.Dequeue();
                    wastedWater += currentBottles - currentCups;
                }

                else
                {
                    while (currentCups>0)
                    {
                        currentCups -= bottles.Pop();
                        if (currentCups<0)
                        {
                            currentCups *= -1;
                            wastedWater += currentCups;
                            break;
                        }
                    }
                    cups.Dequeue();
                }
            }

            if(bottles.Count>0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
            }

            else if(cups.Count>0)
            {
                Console.WriteLine($"Cups: {string.Join(" ",cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
