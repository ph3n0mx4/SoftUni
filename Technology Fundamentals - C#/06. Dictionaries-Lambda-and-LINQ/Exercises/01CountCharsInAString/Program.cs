using System;
using System.Collections.Generic;

namespace _01CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string someText = Console.ReadLine();
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < someText.Length; i++)
            {
                if(someText[i]==' ')
                { continue; }
                if(dict.ContainsKey(someText[i]))
                {
                    dict[someText[i]]++;
                }

                else
                {
                    dict.Add(someText[i], 1);
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
