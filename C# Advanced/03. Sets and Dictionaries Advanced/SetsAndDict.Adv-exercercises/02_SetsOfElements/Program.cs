using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];

            var nSet = new HashSet<int>();
            var mSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                nSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                mSet.Add(int.Parse(Console.ReadLine()));
            }

            var result = new HashSet<int>();

            foreach (var nNum in nSet)
            {
                if(mSet.Contains(nNum))
                {
                    result.Add(nNum);
                }
                
            }
            
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
