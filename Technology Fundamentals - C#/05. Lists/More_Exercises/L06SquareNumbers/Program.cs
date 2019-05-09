using System;
using System.Collections.Generic;
using System.Linq;

namespace L06SquareNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> someNums = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(double.Parse).ToList();
            List<int> result = new List<int>();

            foreach (var num in someNums)
            {
                if(Math.Sqrt(num)== (int)Math.Sqrt(num))
                {
                    result.Add((int)num);
                }
                
            }

            result.Sort();
            result.Reverse();
            Console.WriteLine(string.Join(' ',result));
        }
    }
}
