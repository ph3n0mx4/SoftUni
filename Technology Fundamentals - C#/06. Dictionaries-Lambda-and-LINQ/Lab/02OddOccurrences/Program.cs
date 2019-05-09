using System;
using System.Collections.Generic;
using System.Linq;

namespace _02OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().ToLower().Split().ToList();
            Dictionary <string, int> dict = new Dictionary<string, int>();

            foreach(var word in words)
            {
                if(dict.ContainsKey(word))
                {
                    dict[word]++;
                }

                else
                {
                    dict[word] = 1;
                }
            }

            List<string> result = new List<string>();
            foreach (var word in dict)
            {
                if(word.Value %2==1)
                {
                    result.Add(word.Key);
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
