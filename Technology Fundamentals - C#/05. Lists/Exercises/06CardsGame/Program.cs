using System;
using System.Collections.Generic;
using System.Linq;

namespace _06CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numsFirst = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> numsSecond = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            
            while(numsFirst.Count!=0 && numsSecond.Count !=0)
            {
                if(numsFirst[0]>numsSecond[0])
                {
                    numsFirst.Add(numsFirst[0]);
                    numsFirst.Add(numsSecond[0]);
                    numsFirst.RemoveAt(0);
                    numsSecond.RemoveAt(0);
                }

                else if (numsSecond[0]> numsFirst[0])
                {
                    numsSecond.Add(numsSecond[0]);
                    numsSecond.Add(numsFirst[0]);
                    numsFirst.RemoveAt(0);
                    numsSecond.RemoveAt(0);
                }
                
                else
                {
                    numsFirst.RemoveAt(0);
                    numsSecond.RemoveAt(0);
                }
            }
            int sumOne = numsFirst.Sum();
            int sumTwo = numsSecond.Sum();

            if(numsFirst.Count==0)
            {
                Console.WriteLine($"Second player wins! Sum: {sumTwo}");
            }

            else
            {
                Console.WriteLine($"First player wins! Sum: {sumOne}");
            }
        }
    }
}
