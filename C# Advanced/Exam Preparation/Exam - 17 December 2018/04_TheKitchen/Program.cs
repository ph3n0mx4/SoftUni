using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_TheKitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequenceKnives = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sequenceForks = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var knive = new Stack<int>(sequenceKnives);
            var forks = new Queue<int>(sequenceForks);

            var set = new List<int>();

            while (knive.Count>0 && forks.Count>0)
            {
                int currentKnife = knive.Peek();
                int currentFork = forks.Peek();

                if(currentKnife>currentFork)
                {
                    set.Add(knive.Pop() + forks.Dequeue());
                }

                else if (currentKnife == currentFork)
                {
                    forks.Dequeue();
                    knive.Push(knive.Pop()+1);
                }

                else if (currentKnife<currentFork)
                {
                    knive.Pop();
                }
            }

            Console.WriteLine($"The biggest set is: {set.Max()}");
            Console.WriteLine(string.Join(" ",set));
        }
    }
}
