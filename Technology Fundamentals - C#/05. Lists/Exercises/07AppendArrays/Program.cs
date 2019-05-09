using System;
using System.Collections.Generic;
using System.Linq;

namespace _07AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine().Split('|').ToList();
            text.Reverse();

            List<int> nums = new List<int>();

            for (int i = 0; i < text.Count; i++)
            {
                List<int> result = text[i].Split(' ',StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse).ToList();
                nums.AddRange(result);
            }

            Console.WriteLine(string.Join(' ',nums));
        }
    }
}
