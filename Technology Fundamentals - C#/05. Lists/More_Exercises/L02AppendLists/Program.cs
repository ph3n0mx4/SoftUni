using System;
using System.Collections.Generic;
using System.Linq;

namespace L02AppendLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> someText = Console.ReadLine()
                                             .Split('|',StringSplitOptions.RemoveEmptyEntries)
                                             .ToList();
            someText.Reverse();
            List<int> result = new List<int>();
            for (int i = 0; i < someText.Count; i++)
            {
                List<int> number = someText[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                              .Select(int.Parse).ToList();
                result.AddRange(number);
            }

            Console.WriteLine(string.Join(' ',result));
        }
    }
}
