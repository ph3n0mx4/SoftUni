using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" | ");
            string[] wordsForCheck = Console.ReadLine().Split(" | ");
            string cmd = Console.ReadLine();

            var dict = new Dictionary<string, List<string>>();

            int count = words.Length;
            for (int i = 0; i < count; i++)
            {
                string[] wordAndDefinition = words[i].Split(": ");
                string word = wordAndDefinition[0];
                string definition = wordAndDefinition[1];

                if(!dict.ContainsKey(word))
                {
                    dict[word] = new List<string>();
                }

                dict[word].Add(definition);
            }

            int count2 = wordsForCheck.Length;
            for (int i = 0; i <count2 ; i++)
            {
                string word = wordsForCheck[i];
                
                if(!dict.ContainsKey(word))
                {
                    continue;
                }

                List<string> definition = dict[word];
                
                Console.WriteLine($"{word}");
                foreach (var item in definition.OrderBy(x => -x.Length))
                {
                    Console.WriteLine($" -{item}");
                }
            }

            if(cmd== "End")
            {
                return;
            }

            else if(cmd== "List")
            {
                var result = new List<string>();
                foreach (var kvp in dict.OrderBy(x=>x.Key))
                {
                    result.Add(kvp.Key);
                }

                Console.WriteLine(string.Join(' ',result));
            }
        }
    }
}
