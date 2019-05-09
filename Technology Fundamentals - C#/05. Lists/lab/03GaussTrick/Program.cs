using System;
using System.Collections.Generic;
using System.Linq;

namespace _03GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToList();
            List<int> result = new List<int>();
            int halfSequence = sequence.Count / 2;
            
            for (int i = 0; i < halfSequence; i++)
            {
                result.Insert(i,sequence[i] + sequence[sequence.Count - i -1]);
            }

            if(sequence.Count%2==1)
            {
                result.Add(sequence[sequence.Count / 2]);
            }
            
            Console.WriteLine(string.Join(' ',result));
        }
    }
}
