using System;
using System.Collections.Generic;

namespace _04_EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int currnetNum = int.Parse(Console.ReadLine());
                
                if(!numbers.ContainsKey(currnetNum))
                {
                    numbers[currnetNum] = 0;
                }

                numbers[currnetNum]++;
                
            }

            foreach (var num in numbers)
            {
                if(num.Value%2==0)
                {
                    Console.WriteLine(num.Key);
                }
                
            }
        }
    }
}
