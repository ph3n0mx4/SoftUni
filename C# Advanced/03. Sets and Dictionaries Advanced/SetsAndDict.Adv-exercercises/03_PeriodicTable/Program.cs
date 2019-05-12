using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var compounds = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                foreach (var compound in input)
                {
                    compounds.Add(compound);    
                }
            }

            Console.WriteLine(string.Join(" ",compounds));
        }
    }
}
