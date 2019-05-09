using System;
using System.Collections.Generic;
using System.Linq;


namespace _03WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> words= new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                
                if(words.ContainsKey(word)==false)
                {
                    words.Add(word, new List<string>());
                }
                words[word].Add(synonym);
                
            }

            foreach (var item in words)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ",item.Value)}");
            }


        }
    }
}
