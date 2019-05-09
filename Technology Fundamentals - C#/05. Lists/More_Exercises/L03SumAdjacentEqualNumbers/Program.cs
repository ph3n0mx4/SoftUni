using System;
using System.Collections.Generic;
using System.Linq;

namespace L03SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> listOfNumber = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();

            for (int i = 0; i < listOfNumber.Count - 1; i++)
            {
                if (listOfNumber[i] == listOfNumber[i + 1])
                {
                    listOfNumber[i] += listOfNumber[i + 1];
                    listOfNumber.RemoveAt(i + 1);
                    i = -1;
                }

            }
            Console.WriteLine(string.Join(' ',listOfNumber));
        }
    }
}
