using System;
using System.Linq;
using System.Collections.Generic;

namespace L1RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfInt = Console.ReadLine()
                                  .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToList();
            List<int> listResult = new List<int>();
            for (int i = 0; i < listOfInt.Count; i++)
            {
                if(listOfInt[i]>0)
                {
                    listResult.Add(listOfInt[i]);
                }
            }

            listResult.Reverse();
            if(listResult.Count==0)
            {
                Console.WriteLine("empty");
            }

            else
            {
                Console.WriteLine(string.Join(' ',listResult));
            }
        }
    }
}
